using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
	public MissilePattern pattern;

	public Transform target;

	private void OnDrawGizmos()
	{
		Vector2 pos = (Vector2)transform.position + Vector2.up * 2;
		for (int i = 0; i < 6; i++)
		{
			Vector2 targetPos = new Vector2(Mathf.Sin(Mathf.Deg2Rad * i * 60), Mathf.Cos(Mathf.Deg2Rad * i * 60)) + (Vector2)transform.position;

			Gizmos.DrawWireCube(targetPos, Vector3.one);
		}
	}

	void Update()
    {
        if(Input.GetKeyDown("g"))
		{
			LaunchMissile(pattern, target.position);
		}
    }

	public void LaunchMissile(MissilePattern pattern, Vector2 target)
	{
		Vector2 dir = (target - (Vector2)transform.position).normalized;


		//需要目标
		if (pattern.targetType == MissionTargetType.Target)
		{
			for (int i = 0; i < pattern.amount; i++)
			{
				Vector2 targetPos = new Vector2(Mathf.Sin(Mathf.Deg2Rad * i * 60), Mathf.Cos(Mathf.Deg2Rad * i * 60)) + (Vector2)transform.position;
				targetPos = targetPos - (Vector2)transform.position;

				StartCoroutine(LaunchMissile(pattern.missilePrefab, Vector2ToRotation(targetPos), pattern.damage, pattern.speed));
			}
		}
	}

	IEnumerator LaunchMissile(GameObject missilePrefab, Quaternion rotation, int damage, float speed)
	{
		Transform missile = Instantiate(missilePrefab, transform.position, rotation).transform;

		//朝向目标

		float lifetime = 3f;

		while(lifetime > 0)
		{
			lifetime -= Time.fixedDeltaTime;

			missile.Translate(missile.right * speed * Time.fixedDeltaTime, Space.World);

			yield return new WaitForFixedUpdate();
		}

		Destroy(missile.gameObject);
	}

	Quaternion Vector2ToRotation(Vector2 dir)
	{
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		return rotation;
	}
}
