using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilTargetType
{
	Null,
	Point,
	Unit
}

[CreateAssetMenu(menuName = "ScriptableObjects/Abil")]
public class Abil : ScriptableObject
{
    [Header("属性设置")]
    //目标类型
    public AbilTargetType targetType;

	//释放效果
    public Effect castEffect;

	//范围效果
	public Effect areaEffect;

	//释放动画
	public Anim anim;

	//前摇、释放、后摇时间
	public float preswingTime, swingTime, backswingTime;

	//能在空中释放
	public bool canCastInTheAir = false;

}
