using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cirno : MonoBehaviour
{
	public Unit target;

	Unit unit;

	public Abil abil_Spell1;
	public Abil abil_Spell2;

	void Start()
	{
		unit = GetComponent<Unit>();
	}

    void Update()
    {
		//超出所有技能范围，朝玩家移动，否则释放范围足够的技能
		//一阶段：发射飞弹、发射飞弹下砸、延迟冰锥
		//二阶段：瞬移挥砍、瞬移背刺、
		//三阶段：巨剑冲刺、巨剑跳劈

		Vector2 dis = target.transform.position - transform.position;
		if(Mathf.Abs(dis.x) > 6)
		{
			int dir = dis.x > 0 ? 1 : -1;
			unit.Move(dir);
		}
		else
		{
			unit.StopMoving();

			unit.CastAbil(abil_Spell1);
		}
    }
}
