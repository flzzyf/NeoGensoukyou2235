using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using UnityEditor.IMGUI.Controls;

[CustomEditor(typeof(AbilController))]
public class AbilControllerEditor : Editor
{
	AbilController abilController;

	SphereBoundsHandle sphereBoundsHandle;

	private void OnEnable()
	{
		abilController = (AbilController)target;

		sphereBoundsHandle = new SphereBoundsHandle();
	}

	public void OnSceneGUI()
	{
		//绘制球形范围显示
		Handles.color = Color.blue;

		Vector2 pos = (Vector2)abilController.transform.position + abilController.abilOffset;
		sphereBoundsHandle.center = pos;
		sphereBoundsHandle.radius = abilController.abilRadius;

		sphereBoundsHandle.DrawHandle();

		abilController.abilRadius = sphereBoundsHandle.radius;
		abilController.abilOffset = (Vector2)sphereBoundsHandle.center - (Vector2)abilController.transform.position;

		abilController.abilOffset = Handles.PositionHandle((Vector2)abilController.transform.position + abilController.abilOffset, Quaternion.identity) - abilController.transform.position;

		//保存修改（加入Undo）
		EditorUtility.SetDirty(abilController);
		Undo.RecordObject(abilController, "Inspector");

	}
}
