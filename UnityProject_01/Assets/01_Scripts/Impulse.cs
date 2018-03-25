using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Impulse
{
	public float impulseValue;
	public float velocity;
	public float min;
	public float max;
	public float acceleration;
	public float deceleration;

	public void update(float value)
	{
		float PRESSED_VALUE = velocity + (value * Time.deltaTime * acceleration);
		float UNPRESSED_VALUE = velocity * deceleration;
		velocity = Mathf.Clamp((value == 0) ? UNPRESSED_VALUE : PRESSED_VALUE, min, max );
		impulseValue += velocity * Time.deltaTime;
	}
}
