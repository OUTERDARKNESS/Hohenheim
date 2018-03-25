using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	public InputController inputController;
	public MovementController movementController;
	
	void Update ()
	{
		inputController.UpdateAll();
		movementController.MoveAlongTrack(inputController.trackImpulse.impulseValue);
		//movementController.MoveForward(inputController.movementImpulse.velocity);
		//movementController.MoveInZ(inputController.movementImpulse.impulseValue);

		movementController.RotateAlongY(inputController.rotationImpulse.impulseValue);


	}
}
