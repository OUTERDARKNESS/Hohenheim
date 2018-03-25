using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

	public Transform MoverTrans;
	public Transform RotationTrans;

	public void MoveInZ (float Amount)
	{
		Vector3 Pos = MoverTrans.position;
		Pos.z = Amount;
		MoverTrans.position = Pos;
	}

	public void MoveForward ( float Amount )
	{
		MoverTrans.Translate ( Vector3.forward * Amount );
	}

	public void MoveAlongTrack ( float Amount )
	{
		MoverTrans.position = Track.GetPos ( KeepInBounds ( Amount ) );
		MoverTrans.LookAt ( Track.GetPos ( KeepInBounds ( Amount ) + 0.001f ) );
	}

	private float KeepInBounds (float val)
	{
		float result = val;
		if ( val > 1f ) { result -= Mathf.Floor ( val ); }
		if ( val < 0f ) { result += Mathf.Ceil ( Mathf.Abs ( val ) ); }
		return result;
	}


	public void RotateAlongY ( float Amount )
	{
		Vector3 Rot = RotationTrans.localEulerAngles;
		Rot.y = Amount;
		RotationTrans.localEulerAngles = Rot;
	}
}
