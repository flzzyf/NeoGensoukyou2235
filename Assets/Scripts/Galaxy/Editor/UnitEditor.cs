using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Unit))]
public class UnitEditor : Editor
{
	Unit unit;

	private void OnEnable()
	{
		unit = (Unit)target;
	}

	public void OnSceneGUI()
	{
		//创建对话框，滑动条和按钮
		Handles.BeginGUI();
		{
			GUIStyle boxSytle = new GUIStyle("box");

			GUILayout.BeginArea(new Rect(10, 10, 200, 70), boxSytle);
			{
				GUILayout.Label("单位");

				if (GUILayout.Button("翻转单位"))
				{
					unit.FlipInSceneView();
				}
			}

			GUILayout.EndArea();
		}

		Handles.EndGUI();
	}
}
