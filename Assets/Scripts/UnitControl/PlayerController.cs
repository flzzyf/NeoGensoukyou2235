using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	PlayerControls controls;

	public Unit unit;

	Vector2 input;
	Vector2 lastInput;

	private void Awake()
	{
		controls = new PlayerControls();

		//按钮
		controls.GamePlay.Attack.performed += ctx => Attack();

		controls.GamePlay.Jump.performed += ctx => Jump();
		controls.GamePlay.Jump.canceled += ctx => JumpCanceled();

		controls.GamePlay.Roll.performed += ctx => Roll();
		controls.GamePlay.Item.performed += ctx => UseItem();

		//摇杆
		controls.GamePlay.Move.performed += ctx => input = ctx.ReadValue<Vector2>();
		controls.GamePlay.Move.canceled += ctx => input = Vector2.zero;
	}

	private void Update()
	{
		//移动判定
		if(!unit.acting)
		{
			if(input.x != lastInput.x)
			{
				if (input.x != 0)
				{
					unit.Move(input.x);
				}
				else
				{
					unit.StopMoving();
				}
			}

			lastInput = input;
		}
		else
		{
			lastInput = Vector2.zero;
		}
	}

	private void OnEnable()
	{
		controls.GamePlay.Enable();
	}

	private void OnDisable()
	{
		controls.GamePlay.Disable();
	}

	void Attack()
	{
		unit.Attack2();
	}

	void Jump()
	{
		unit.Jump();
	}

	void JumpCanceled()
	{
		unit.JumpCancel();
	}

	void Roll()
	{
		unit.Roll();
	}

	void UseItem()
	{
		unit.UseItem();
	}
}
