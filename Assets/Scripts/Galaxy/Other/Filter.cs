using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AllyOrEnemy { Ally, Enemy}

public class Filter
{
    public AllyOrEnemy allyOrEnemy;

	//判断可作为目标
	//public bool IsAvailableTarget(Actor caster, Actor target)
	//{
	//	if(allyOrEnemy == AllyOrEnemy.Enemy && caster.IsEnemy(target))
	//	{
	//		return true;
	//	}

	//	return false;
	//}
}
