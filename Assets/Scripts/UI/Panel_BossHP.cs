using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_BossHP : MonoBehaviour
{
	public Text text_Name;
	public Text text_Damage;

	public Panel_Slider slider;

	public void Init(string name, Unit unit)
	{
		text_Name.text = name;

		slider.Init(unit);
	}

	public void Set(int value)
	{
		//slider.Set(value);

		//如果是伤害，显示伤害数字
		if(value < 0)
		{
			text_Damage.text = value.ToString();
		}
	}
}
