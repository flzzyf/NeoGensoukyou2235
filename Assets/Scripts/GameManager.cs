using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Cirno cirno;

    void Start()
    {
		//SoundManager.instance.PlaySound("Cirno_Phase1", true);
    }

	private void Update()
	{
		if(Input.GetKeyDown("f"))
		{
			//SoundManager.instance.StopPlayBGM();

			//cirno.Attack2();
		}
	}
}
