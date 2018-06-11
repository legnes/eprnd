using UnityEngine;
using System.Collections;

public class MenuLevelLoad : MonoBehaviour {

	public int level;

	Color vis;
	Color invis;

	bool mouse = false;
	
	void Start() {
		vis = GetComponent<Renderer>().material.color;
		invis = vis;
		invis [3] = 0f;
	}

	void FixedUpdate() {
		if(mouse) {
			if (Random.Range(0,100) > 80)
				GetComponent<Renderer>().material.color = invis;
			else GetComponent<Renderer>().material.color = vis;
		}
	}

	void OnMouseEnter() {
		mouse = true;
	}

	void OnMouseExit() {
		GetComponent<Renderer>().material.color = vis;
		mouse = false;
	}

	void OnMouseDown() {
		if(level < 0) Application.Quit();
		if(Application.CanStreamedLevelBeLoaded (level + 2)) Application.LoadLevel (level + 2);
	}
}
