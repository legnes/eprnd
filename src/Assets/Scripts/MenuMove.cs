using UnityEngine;
using System.Collections;

public class MenuMove : MonoBehaviour {

	public GameObject trgt;

	CameraFollowController camfollow;

	Color vis;
	Color invis;

	bool mouse = false;

	void Start() {
		Time.timeScale = 1.0f;
		Cursor.visible = true;
		vis = GetComponent<Renderer>().material.color;
		invis = vis;
		invis [3] = 0f;

		camfollow = (CameraFollowController)Camera.main.GetComponent (typeof(CameraFollowController));
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
		camfollow.cameraTarget = trgt;
	}
}