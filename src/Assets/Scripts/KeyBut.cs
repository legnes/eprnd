using UnityEngine;
using System.Collections;

public class KeyBut {
	
	public Vector3 center;
	public float top;
	public float bot;
	public float left;
	public float right;
	public bool trig;
	
	// Constructor
	public KeyBut(float centx, float centy, float t, float b, float l, float r)
	{
		center.x = 2*centx;
		center.y = 2*centy;
		center.z = 0f;
		top = 2*t;
		bot = 2*b;
		left = 2*l;
		right = 2*r;
		trig = false;
	}
}

