using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Valve.VR;

public class InputController : MonoBehaviour
{
	public Impulse movementImpulse;
	public Impulse rotationImpulse;
	public Impulse trackImpulse;
	public Vector2 DirectionalInput;

	/// <summary>
	/// If true, horizontal and vertical cannot be used simultanously. 
	/// Useful for directional VR input on the touchpad
	/// </summary>
	public bool DirectionalInput_IsLimitedToOneAxisAtATime = false;

	public void UpdateAll ()
	{
		Update_Input ();
		Update_Impluse();
	}

	private void Update_Input ()
	{
		Vector2 RawPadInput = Vector2.zero;

		//--- Old stuff realted to VR input
		/*
		var ctlr = PlayerVR.instance.Ctrlr_R;
		if (!ctlr.padPressed)
		{
			Input = Vector2.zero;
			return;
		}
		var device = SteamVR_Controller.Input ( (int) ctlr.controllerIndex );
		Vector2 RawPadInput = device.GetAxis ( EVRButtonId.k_EButton_SteamVR_Touchpad );
		*/

		//-- New input is mapped to Unity's input axis assignmnets
		RawPadInput.x = Input.GetAxis ("Horizontal");
		RawPadInput.y = Input.GetAxis ( "Vertical" );

		DirectionalInput.x = snapInput ( RawPadInput.x );
		DirectionalInput.y = snapInput ( RawPadInput.y );

		if( DirectionalInput_IsLimitedToOneAxisAtATime )
		{
			bool isHorizontal = Mathf.Abs ( RawPadInput.x ) > Mathf.Abs ( RawPadInput.y );
			if ( isHorizontal )
			{
				DirectionalInput.y = 0f;
			}
			else
			{
				DirectionalInput.x = 0f;
			}
		}
	}

	float snapInput(float value)
	{
		float result = 0f;
		if ( value > 0f ) { result = 1f; }
		if ( value < 0f ) { result = -1f; }
		return result;
	}

	private void Update_Impluse ()
	{
		rotationImpulse.update ( DirectionalInput.x );
		movementImpulse.update ( DirectionalInput.y );
		trackImpulse.update ( DirectionalInput.y );
	}
}


