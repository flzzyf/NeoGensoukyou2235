using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Effect/Force")]
public class Effect_Force : Effect
{
    public float amount = 3;

    public override void Trigger()
    {
		Vector2 dir;
		RigidbodyBox rb;

		//如果目标是施法者则向前方施力
		if (targetType == EffectTargetType.Caster)
		{
			dir = new Vector2(caster.facing, 0.25f).normalized;


			rb = caster.rb;
		}
		else
		{
			dir = new Vector2(Mathf.Sign((target.transform.position - caster.transform.position).x), 0.2f).normalized;

			rb = target.rb;
		}

		rb.AddForce(dir * amount);
	}
}
