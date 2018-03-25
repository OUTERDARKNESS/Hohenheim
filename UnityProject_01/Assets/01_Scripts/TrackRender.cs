using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent (typeof(LineRenderer))]
public class TrackRender : MonoBehaviour {

	public int NumSegments = 100;
	LineRenderer LR;

	void Start ()
	{
		LR = GetComponent<LineRenderer> ();
	}	
	
	void Update ()
	{
		LR.positionCount = NumSegments;
		Vector3[] Pos = new Vector3[NumSegments];

		for ( int i = 0; i < NumSegments; i++ )
		{
			Pos[i] = Track.GetPos ( (float) i / (float) NumSegments );
		}

		LR.SetPositions ( Pos );
	}
}
