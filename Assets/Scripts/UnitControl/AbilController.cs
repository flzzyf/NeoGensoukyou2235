using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilController : MonoBehaviour
{
	public Vector2 abilOffset;
	public float abilRadius;

	Unit unit;

	public LayerMask unitLayer;

	//行动中
	[HideInInspector]
	public bool acting;

	//效果范围指示器
	public Transform areaDisplay;

	//区域效果
	Effect areaEffect;

	void Start()
	{
		unit = GetComponent<Unit>();
	}

	//目标单位组（为了不重复击中目标
	List<GameObject> targetList;

	//搜索目标
	void Update()
	{
		if(abilRadius > 0)
		{
			//创建目标单位组
			if(targetList == null)
				targetList = new List<GameObject>();

			//搜索区域偏移
			Vector2 offset = (Vector2)unit.transform.position + abilOffset * new Vector2(unit.facing, 1);

			//搜索区域
			foreach (var item in Physics2D.OverlapCircleAll(offset, abilRadius, unitLayer))
			{
				//跳过自己，或者已经搜索过的目标，或者无敌目标
				if (item.gameObject == gameObject || targetList.Contains(item.gameObject) || item.GetComponent<Unit>().invincible)
					continue;

				//加入单位组
				targetList.Add(item.gameObject);

				//方向
				Vector2 dir = (item.transform.position - transform.position).normalized;

				//施加效果
				areaEffect.Trigger(unit, item.GetComponent<Unit>());

			}

			//效果范围指示器
			if (areaDisplay != null)
			{
				areaDisplay.gameObject.SetActive(true);

				areaDisplay.localPosition = abilOffset * new Vector2(unit.facing, 1);

				areaDisplay.localScale = Vector3.one * abilRadius * 2;
			}
		}
		else
		{
			//隐藏效果范围指示器
			if (areaDisplay != null)
				areaDisplay.gameObject.SetActive(false);

			//清空目标单位组
			if (targetList != null)
				targetList = null;
		}
	}

	//预输入指令
	Abil nextAbil;

	//释放技能
	public void CastAbil(Abil abil)
	{
		//如果已经在行动中，设置预输入指令
		if (acting)
		{
			nextAbil = abil;

			return;
		}

		//如果不能在空中释放
		if (!unit.rb.isOnGround && !abil.canCastInTheAir)
			return;

		//前摇
		unit.StopMoving();

		//释放效果
		if(abil.castEffect != null)
			abil.castEffect.Trigger(unit);

		areaEffect = abil.areaEffect;

		//播放动画，根据时长
		unit.actor.PlayAnim(abil.anim, abil.preswingTime, abil.swingTime, abil.backswingTime);

		StartCoroutine(CastAbilCor(abil));
	}

	IEnumerator CastAbilCor(Abil abil)
	{
		acting = true;

		yield return new WaitForSeconds(abil.preswingTime);
		//释放

		yield return new WaitForSeconds(abil.swingTime);

		yield return new WaitForSeconds(abil.backswingTime);
		//后摇

		acting = false;

		//如果有预输入指令，执行指令
		if(nextAbil != null)
		{
			CastAbil(nextAbil);

			nextAbil = null;
		}
	}
}
