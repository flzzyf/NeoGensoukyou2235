using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Anim { Stand, Walk, Attack, Attack2, Jump }

public class Actor : MonoBehaviour
{
	Animator animator;

	//重载前动画和重载后动画List
	List<KeyValuePair<AnimationClip, AnimationClip>> clips;

	void Start()
	{
		animator = GetComponent<Animator>();

		clips = new List<KeyValuePair<AnimationClip, AnimationClip>>();
		((AnimatorOverrideController)animator.runtimeAnimatorController).GetOverrides(clips);
	}

    public void Walk(float inputH)
	{
		animator.SetFloat("Speed", inputH);

		print("move");
		//animator.
	}

	public void StopWalking()
	{

	}

	public void SetBool(string name, bool b)
	{
		animator.SetBool(name, b);
	}

	#region 攻击

	public int attackCount = 2;
	int currentAttackIndex;

	public void Attack()
	{
		if (currentAttackIndex == 0)
			StartCoroutine(PlayAnim(Anim.Attack));
		else
			StartCoroutine(PlayAnim(Anim.Attack2));

		if (currentAttackIndex == attackCount - 1)
			currentAttackIndex = 0;
		else
			currentAttackIndex++;

		//animator.SetInteger("Attack", currentAttackIndex);


	}

	IEnumerator PlayAnim(Anim anim)
	{
		AnimationClip clip = GetClip(anim, true);

		print(anim.ToString());

		animator.Play(anim.ToString());

		float preattackTime = 1f;
		float attackTime = 2f;

		float preattackTimeSpeed = clip.events[0].time / preattackTime;

		animator.speed = preattackTimeSpeed;

		yield return new WaitForSeconds(preattackTime);

		float attackTimeSpeed = (clip.length - clip.events[0].time) / attackTime;

		animator.speed = attackTimeSpeed;

		yield return new WaitForSeconds(attackTime);

		animator.speed = 1;
	}

	public void AttackEnd()
	{
		animator.SetInteger("Attack", 0);

		currentAttackIndex = 0;
	}

	#endregion

	public void EmptyEvent()
	{

	}

	//获取动画（根据是否是重载的动画）
	public AnimationClip GetClip(Anim anim, bool overrided)
	{
		for (int i = 0; i < clips.Count; i++)
		{
			if (clips[i].Key.name == anim.ToString())
			{
				if (overrided)
				{
					return clips[i].Value;
				}
				else
				{
					return clips[i].Key;
				}
			}
		}

		Debug.LogError("未能找到动画：" + anim.ToString());

		return null;
	}

}
