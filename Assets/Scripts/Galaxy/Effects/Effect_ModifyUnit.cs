using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "ScriptableObjects/Effect/ModifyUnit")]
public class Effect_ModifyUnit : Effect
{
	public int hpModify;

    public override void Trigger()
    {
		if (hpModify != 0)
		{
			if(hpModify < 0)
			{
				target.TakeDamage(-hpModify);
			}
			else
			{
				target.ModifyHp(hpModify);
			}
		}
    }

}
