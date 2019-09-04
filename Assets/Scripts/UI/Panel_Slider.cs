using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Slider : MonoBehaviour
{
	Slider slider;

	public Unit unit;

	private void Start()
	{
		slider = GetComponent<Slider>();


	}

	private void Update()
	{
		if(unit != null)
		{
			Set();
		}
	}

	public void Init(Unit unit)
	{
		this.unit = unit;

		Set();
	}

	public void Set()
	{
		slider.value = (float)unit.hpCurrent / unit.hpMax;
	}
}
