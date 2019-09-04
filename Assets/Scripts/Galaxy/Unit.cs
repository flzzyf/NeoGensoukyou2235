using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
	public float speed = 7;

	[HideInInspector] public RigidbodyBox rb;

	public Vector2 centerPoint { get { return (Vector2)transform.position + Vector2.up * rb.boxCollider.transform.localScale.y / 2; } }

	[HideInInspector]
	public Actor actor;

	public bool acting { get { return abilController.acting; } }

	//无敌状态
	public bool invincible;

	void Awake()
	{
		rb = GetComponent<RigidbodyBox>();

		actor = GetComponentInChildren<Actor>();

		abilController = GetComponent<AbilController>();
	}

	void Start()
    {
		InitJumpVelocity();
		InitHp();

		rb.onLeaveGround += LeaveGround;
		rb.onLand += Land;
    }

	#region 移动

	public void Move(float inputH)
	{
		if (abilController.acting)
			return;

		rb.movingForce = new Vector2(inputH * speed, 0);

		actor.Walk(Mathf.Abs(inputH));

		//面向移动方向
		FlipToward((int)Mathf.Sign(inputH));
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
		if (!rb.isOnGround || abilController.acting)
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

	#region 朝向

	public bool facingRight = true;
	public int facing { get { return facingRight ? 1 : -1; } }

	//水平翻转
	public void Flip()
	{
		facingRight = !facingRight;

		actor.Flip();
	}

	public void FlipInSceneView()
	{
		facingRight = !facingRight;

		GetComponent<Actor>().Flip();
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
			ModifyHp(-amount);

			print("剩余生命：" + hpCurrent);

			//播放被击动画
			actor.Hit();
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

		Destroy(gameObject);

		//GameOverMgr.instance.GameOver();
	}

	public void DieAnimEvent()
	{
		Destroy(gameObject);
	}

	#endregion

	AbilController abilController;

	public Abil[] abils;

	public void CastAbil(Abil abil)
	{
		abilController.CastAbil(abil);
	}

	public void Attack2()
	{
		abilController.CastAbil(abils[0]);
	}

	public void Roll()
	{
		abilController.CastAbil(abils[1]);

	}

	public void UseItem()
	{

	}
}
