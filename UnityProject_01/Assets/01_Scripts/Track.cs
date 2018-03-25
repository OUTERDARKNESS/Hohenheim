using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Track : MonoBehaviour {

	public static Track instance
	{
		get
		{
			if ( _instance == null)
			{
				_instance = FindObjectOfType<Track> ();
			}
			return _instance;
		}
		set
		{
			_instance = value;
		}
	}
	private static Track _instance;

	public float ScaleMult = 10f;
	public AnimationCurve Curve_X;
	public AnimationCurve Curve_Y;
	public AnimationCurve Curve_Z;

	void Start ()
	{
		instance = this;
	}
	
	public static Vector3 GetPos (float t)
	{
		return (new Vector3 ( instance.Curve_X.Evaluate ( t ), instance.Curve_Y.Evaluate ( t ), instance.Curve_Z.Evaluate ( t ) ) * instance.ScaleMult) + instance.transform.position;
	}
}
