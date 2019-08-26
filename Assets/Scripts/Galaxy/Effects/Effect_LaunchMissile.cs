using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Effect/LaunchMissile")]
public class Effect_LaunchMissile : Effect
{
	public Transform prefab_Missile;
	public Mover mover;

	public void Trigger(Actor caster, Vector2 targetPoint)
	{
		Vector2 dir = targetPoint - (Vector2)caster.transform.position;
		dir.Normalize();

		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		Transform missile = Instantiate(prefab_Missile, caster.transform.position, rotation);

		FindObjectOfType<MonoBehaviour>().StartCoroutine(LaunchMissile(missile, mover, targetPoint));
	}

	IEnumerator LaunchMissile(Transform missile, Mover mover, Vector2 targetPoint)
	{
		RaycastHit2D hit;

		while(true)
		{
			hit = Physics2D.Raycast(missile.position, missile.right, mover.speed * Time.fixedDeltaTime);
			if(hit)
			{
				//判断前方命中目标
				if (hit.collider.CompareTag("Enemy"))
				{
					break;
				}

				//判断是否到达目标点
				if (Vector2.Distance(missile.position, targetPoint) < mover.speed * Time.fixedDeltaTime)
				{
					break;
				}
			}
			

			//移动飞弹
			missile.Translate(missile.right * mover.speed * Time.fixedDeltaTime,Space.World);

			yield return new WaitForFixedUpdate();
		}

		Destroy(missile.gameObject);
	}
}
