using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Anim { Stand, Walk, Attack, Attack2, Jump, Hit, Spell1, Spell2, Spell3, Roll, UseItem }

[RequireComponent(typeof(Animator))]
public class Actor : MonoBehaviour
{
	public GameObject gfx;

	Animator animator;

	//重载前动画和重载后动画List
	List<KeyValuePair<AnimationClip, AnimationClip>> clips;

	void Start()
	{
		animator = GetComponent<Animator>();

		clips = new List<KeyValuePair<AnimationClip, AnimationClip>>();
		((AnimatorOverrideController)animator.runtimeAnimatorController).GetOverrides(clips);
	}

	public void Flip()
	{
		Vector3 scale = gfx.transform.localScale;
		scale.x *= -1;
		gfx.transform.localScale = scale;
	}

    public void Walk(float inputH)
	{
		animator.SetFloat("Speed", inputH);
	}

	public void StopWalking()
	{

	}

	public void SetBool(string name, bool b)
	{
		animator.SetBool(name, b);
	}

	public void Hit()
	{
		animator.Play("Hit");

	}

	//播放动画
	public void PlayAnim(Anim anim, float preswingTime, float swingTime, float backswingTime)
	{
		StartCoroutine(PlayAnimCor(anim, preswingTime, swingTime, backswingTime));
	}

	IEnumerator PlayAnimCor(Anim anim, float preswingTime, float swingTime, float backswingTime)
	{
		AnimationClip clip = GetClip(anim, true);

		animator.Play(anim.ToString(), -1, 0f);

		if(preswingTime != 0 && clip.events.Length >= 1)
		{
			float preswingSpeed = clip.events[0].time / preswingTime;

			animator.speed = preswingSpeed;

			yield return new WaitForSeconds(preswingTime);
		}

		if (swingTime != 0 && clip.events.Length >= 2)
		{
			float swingSpeed = clip.events[1].time / swingTime;

			animator.speed = swingSpeed;

			yield return new WaitForSeconds(swingTime);
		}

		if (backswingTime != 0 && clip.events.Length >= 3)
		{
			float backswingSpeed = clip.events[2].time / backswingTime;

			animator.speed = backswingSpeed;

			yield return new WaitForSeconds(backswingTime);
		}

		animator.speed = 1;
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

		float preattackTime = .5f;
		float attackTime = .5f;

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
