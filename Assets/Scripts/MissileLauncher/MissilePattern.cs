using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MissionTargetType { Null, Target };

[CreateAssetMenu(fileName = "MissilePattern")]
public class MissilePattern : ScriptableObject
{
	//发射信息
	public int angle;
	public int amount;

	public MissionTargetType targetType;

	//飞弹信息
	public GameObject missilePrefab;
	public int damage = 1;
	public float speed = 7;
}
