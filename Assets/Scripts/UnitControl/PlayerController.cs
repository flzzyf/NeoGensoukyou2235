using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Vector2 input;

	public Unit unit;

	float lastInputH;

    void Update()
    {
		input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Vertical"));

		if (unit.isDead)
			return;

		if(Input.GetKeyDown("space"))
		{
			unit.Jump();
		}

		if (Input.GetKeyUp("space"))
		{
			unit.JumpCancel();
		}

		if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton9))
		{
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 dir = mousePos - unit.centerPoint;

			unit.Attack(dir);
		}
	}

	private void FixedUpdate()
	{
		if (unit.isDead)
			return;

		if (input.x != 0)
		{
			unit.Move(input.x);
		}
		else
		{
			if (input.x != lastInputH)
			{
				unit.StopMoving();
			}
		}
		

		lastInputH = input.x;

	}
}
