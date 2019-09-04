using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
	//预设声道数量
	public int numberOfTrack = 6;

	AudioSource[] audioSources;

	//背景音乐音轨
	AudioSource bgmSource;

	private void Awake()
	{
		//创建预设声道
		audioSources = new AudioSource[numberOfTrack];
		for (int i = 0; i < numberOfTrack; i++)
		{
			audioSources[i] = gameObject.AddComponent<AudioSource>();

			audioSources[i].enabled = false;
			audioSources[i].playOnAwake = false;
		}

		bgmSource = gameObject.AddComponent<AudioSource>();
		bgmSource.enabled = false;
		bgmSource.playOnAwake = false;
	}

	//从闲置声道播放声音，如果有的话
	public void PlaySound(Sound sound, bool isBGM = false)
	{
		AudioSource source;
		if(isBGM)
		{
			source = bgmSource;
		}
		else
		{
			source = GetIdleTrack();
		}

		if (source == null)
			return;

		source.enabled = true;
		source.clip = sound.clip;
		source.volume = sound.volume;
		source.loop = sound.loop;

		source.Play();

		StartCoroutine(ClearItWhenItsFinish(source));
	}

	public void PlaySound(string name, bool isBGM = false)
	{
		PlaySound(GetSound(name), isBGM);
	}

	public void StopPlayBGM()
	{
		bgmSource.Stop();
	}

	//播放完毕后清除声轨
	IEnumerator ClearItWhenItsFinish(AudioSource source)
	{
		yield return new WaitForSeconds(source.clip.length);

		source.enabled = false;
	}

	//获取闲置声道
	AudioSource GetIdleTrack()
	{
		for (int i = 0; i < numberOfTrack; i++)
		{
			if(!audioSources[i].enabled)
			{
				return audioSources[i];
			}
		}

		return null;
	}

	//获取声音文件
	Sound GetSound(string name)
	{
		Sound sound = Resources.Load<Sound>("ScriptableObjects/Sound/" + name);
		if (sound == null)
			Debug.LogError("未能找到声音文件：" + name);

		return sound;
	}
}


