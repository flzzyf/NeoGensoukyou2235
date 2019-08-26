using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//声音文件 
[CreateAssetMenu(fileName = "Sound")]
public class Sound : ScriptableObject
{
	public AudioClip clip;

	[Range(0, 1f)]
	public float volume = 1;

	//是否循环播放
	public bool loop = false;
}