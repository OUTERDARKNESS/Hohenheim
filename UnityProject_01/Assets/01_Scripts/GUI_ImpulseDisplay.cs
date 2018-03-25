using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_ImpulseDisplay : MonoBehaviour {

	bool ShowImpuseData = false;
	InputController inputController;

	void Start ()
	{
		inputController = gameObject.GetComponent<InputController> ();
	}

	void OnGUI ()
	{
		GUILayout.BeginHorizontal ();
		GUILayout.Space ( 20 );
		if( GUILayout.Button("Show Inpuse Data"))
		{
			ShowImpuseData = !ShowImpuseData;
		}
		GUILayout.EndHorizontal ();

		GUILayout.Space ( 20 );

		if ( ShowImpuseData )
		{
			DisplayImpulse ( "Track Impulse", inputController.trackImpulse );
			DisplayImpulse ( "Rotation Impulse", inputController.rotationImpulse );
			DisplayImpulse ( "Movement Impulse", inputController.movementImpulse );
		}
	}

	void DisplayImpulse ( string label, Impulse impulse )
	{
		GUILayout.BeginVertical ();
		GUILayout.Box ( label, GUILayout.Width ( 500 ) );
		GUILayout.Space ( 20 );
		LabelInfo ( "impulseValue: ", impulse.impulseValue.ToString ( "000.00" ) );
		LabelInfo ( "velocity: ", impulse.velocity.ToString ( "000.00" ) );
		GUILayout.Space ( 20 );
		LabelInfo ( "acceleration: ", impulse.acceleration.ToString( "000.00" ) );
		LabelInfo ( "deceleration: ", impulse.deceleration.ToString ( "000.00" ) );
		LabelInfo ( "min: ", impulse.min.ToString ( "000.00" ) );
		LabelInfo ( "max: ", impulse.max.ToString ( "000.00" ) );
		GUILayout.EndVertical ();
		GUILayout.Space ( 50 );
	}

	void LabelInfo ( string label, string info )
	{
		GUILayout.BeginHorizontal ();
		GUILayout.Space ( 20 );
		GUILayout.Label ( label, GUILayout.Width(150));
		GUILayout.Box ( info, GUILayout.Width ( 400 ) );
		GUILayout.EndHorizontal ();
	}
}
