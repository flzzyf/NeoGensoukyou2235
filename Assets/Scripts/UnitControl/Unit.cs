using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
	public float speed = 7;

	[HideInInspector] public RigidbodyBox rb;

	public Vector2 centerPoint { get { return (Vector2)transform.position + Vector2.up * rb.boxCollider.transform.localScale.y / 2; } }

	Actor actor;

	void Awake()
	{
		rb = GetComponent<RigidbodyBox>();

		actor = GetComponentInChildren<Actor>();
	}

	void Start()
    {
		InitJumpVelocity();

		rb.onLeaveGround += LeaveGround;
		rb.onLand += Land;
    }

	public CircleCollider2D attackArea;
	public LayerMask targetMask;

	public Transform areaDisplay;

	private void Update()
	{
		if (attackArea == null)
			return;

		if(attackArea.radius > 0.1f)
		{
			Vector2 offset = (Vector2)transform.position + attackArea.offset * new Vector2(facing, 1);
			
			foreach (var item in Physics2D.OverlapCircleAll(offset, attackArea.radius, targetMask))
			{
				Vector2 dir = item.transform.position - transform.position;
				dir.Normalize();
				item.GetComponent<Rigidbody2D>().AddForce(dir * 3, ForceMode2D.Impulse);
			}

			//效果范围指示器
			if (areaDisplay != null)
			{
				areaDisplay.gameObject.SetActive(true);

				areaDisplay.localPosition = attackArea.offset * new Vector2(facing, 1);

				areaDisplay.localScale = Vector3.one * attackArea.radius * 2;
			}
		}
		else
		{
			if (areaDisplay != null)
				areaDisplay.gameObject.SetActive(false);
		}
	}

	#region 移动

	public void Move(float inputH)
	{
		if (isActing)
			return;

		rb.movingForce = new Vector2(inputH * speed, 0);

		actor.Walk(Mathf.Abs(inputH));

		if(inputH != 0)
		{
			//转向
			FlipToward((int)Mathf.Sign(inputH));
		}
	}

	public void StopMoving()
	{
		rb.movingForce = Vector2.zero;

		actor.Walk(0);
	}

	#endregion

	#region 跳跃

	[Header("跳跃参数")]
	//跳跃高度和跳跃时间
	public float jumpHeight = 4;
	public float timeToJump = .4f;

	//松开空格后的跳跃高度
	public float jumpHeightMin = 2;

	float jumpVelocity;
	float jumpVelocityMin;

	//根据跳跃高度和时间换算出跳跃初速度
	void InitJumpVelocity()
	{
		jumpVelocity = (jumpHeight - 0.5f * rb.gravity * timeToJump * timeToJump) / timeToJump;

		jumpVelocityMin = (jumpHeightMin - 0.5f * rb.gravity * timeToJump * timeToJump) / timeToJump;
	}

	public void Jump()
	{
		//接触地面才能跳
		if (!rb.isOnGround || isActing)
			return;

		rb.AddForce(Vector2.up * jumpVelocity);

		actor.SetBool("Jumping", true);

		//LeaveGround();
	}

	//松开空格，停止跳跃
	public void JumpCancel()
	{
		rb.velocity.y = Mathf.Min(rb.velocity.y, jumpVelocityMin);
	}

	bool isFalling;

	void LeaveGround()
	{
		actor.SetBool("IsInTheAir", true);

		StartCoroutine(Falling());
	}

	//着地
	void Land()
	{
		actor.SetBool("IsInTheAir", false);
		actor.SetBool("Jumping", false);

		isFalling = false;
	}

	//掉落计时器
	IEnumerator Falling()
	{
		float timer = 0;

		isFalling = true;

		while(isFalling)
		{
			timer += Time.deltaTime;

			if(timer > 2)
			{
				Death();

				StopAllCoroutines();
			}

			yield return null;
		}
	}

	#endregion

	#region 攻击

	public Abil abil_Attack;

	Abil nextAbil;

	//释放技能
	public void CastAbil(Abil abil)
	{
		if(isActing)
		{
			nextAbil = abil;

			return;
		}

		StartCoroutine(CastAbilCor(abil));
	}

	IEnumerator CastAbilCor(Abil abil)
	{
		//前摇
		StopMoving();

		isActing = true;


		yield return new WaitForSeconds(abil.preswingTime);
		//释放

		yield return new WaitForSeconds(abil.swingTime);

		yield return new WaitForSeconds(abil.backswingTime);
		//后摇

		isActing = false;
	}

	//将会发动攻击（预输入指令）
	bool willAttack;

	bool isActing;

	//朝指定方向攻击
	public void Attack(Vector2 targetPoint)
	{
		if(isActing)
		{
			if (!willAttack)
				willAttack = true;

			return;
		}

		//根据是否在空中影响是否滞空
		if (!rb.isOnGround)
			return;

		StopMoving();

		StartCoroutine(AttackCor());
	}

	IEnumerator AttackCor()
	{
		float attackTime = 1f;

		isActing = true;

		actor.Attack();

		yield return new WaitForSeconds(attackTime);

		isActing = false;


		//继续下次攻击 
		if (willAttack)
		{
			Attack(Vector3.zero);

			willAttack = false;
		}
		else
		{
			actor.AttackEnd();

		}
	}

	#endregion

	#region 朝向

	public bool facingRight = true;
	public int facing { get { return facingRight ? 1 : -1; } }

	//水平翻转
	public void Flip()
	{
		facingRight = !facingRight;

		Vector3 scale = actor.transform.localScale;
		scale.x *= -1;
		actor.transform.localScale = scale;
	}

	//朝向目标方向，1为右，-1为左
	void FlipToward(int dir)
	{
		if (facing != dir)
			Flip();
	}

	//当前正朝向目标方向
	public bool IsFacingTarget(Vector2 pos)
	{
		if (Mathf.Sign(pos.x - transform.position.x) == facing)
		{
			return true;
		}

		return false;
	}

	#endregion

	#region 生命值

	public int hpMax = 5;
	[HideInInspector]
	public int hpCurrent;

	//血条
	//public Panel_HealthBar panel_HealthBar;

	void InitHp()
	{
		SetHp(hpMax);

		//if (panel_HealthBar != null)
		//{
		//	panel_HealthBar.Set(hpMax, hpMax);
		//}
	}

	public void SetHp(int amount)
	{
		hpCurrent = amount;

		//if (panel_HealthBar != null)
		//{
		//	panel_HealthBar.Set(hpCurrent);
		//}
	}
	public void ModifyHp(int amount)
	{
		SetHp(hpCurrent += amount);

		if (hpCurrent < 0)
		{
			Death();
		}
	}

	//当受到伤害
	public void TakeDamage(int amount)
	{
		//没死
		if (hpCurrent > amount)
		{
			print("TakeDamage");
			//actor.animator.SetTrigger("Hit");
		}
		else
		{
			Death();
		}
	}

	public bool isDead;

	void Death()
	{
		isDead = true;

		GameOverMgr.instance.GameOver();
	}

	public void DieAnimEvent()
	{
		Destroy(gameObject);
	}

	#endregion
}
