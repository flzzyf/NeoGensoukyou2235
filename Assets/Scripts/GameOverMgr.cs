using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMgr : Singleton<GameOverMgr>
{
	public GameObject panel_YOUDIED;

    public void GameOver()
	{
		SoundManager.instance.PlaySound("YOUDIED");

		panel_YOUDIED.SetActive(true);

		//CameraFollow.instance.smoothSpeed = 0.01f;
		StartCoroutine(ReloadSceneWhenFinish());
	}

	IEnumerator ReloadSceneWhenFinish()
	{
		yield return new WaitForSeconds(5f);

		SceneFader.instance.ReloadScene();
	}
}
