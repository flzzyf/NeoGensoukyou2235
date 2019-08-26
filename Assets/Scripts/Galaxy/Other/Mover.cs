using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//发射物移动器
[CreateAssetMenu(menuName = "ScriptableObjects/Mover")]
public class Mover : ScriptableObject
{
	public float speed = 10;
	public float gravity = -20;
}
