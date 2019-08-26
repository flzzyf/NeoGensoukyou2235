using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Effect/Force")]
public class Effect_Force : Effect
{
    public enum TargetType { Target, Caster }

    public float amount = 3;
    public float time;

    public override void Trigger()
    {
		Vector2 dir;
		RigidbodyBox rb;

		//如果目标是施法者则向前方施力
		if (targetType == EffectTargetType.Caster)
		{
			dir = new Vector2(caster.facing, 0.5f).normalized;

			rb = caster.rb;
		}
		else
		{
			dir = new Vector2(Mathf.Sign((target.transform.position - caster.transform.position).x), 0.5f).normalized;
			//dir = (target.transform.position - caster.transform.position).normalized;

			rb = target.rb;
		}

		rb.AddForce(dir * amount);
	}
}
