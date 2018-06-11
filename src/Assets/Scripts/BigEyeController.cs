using UnityEngine;
using System.Collections;

public class BigEyeController : MonoBehaviour {

	public bool EyesClosed = false;
	//Animator anim;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CloseEyes() {
		EyesClosed = true;
		//print ("closing eyes");
	}

	public void OpenEyes() {
		EyesClosed = false;
		//print ("opening eyes");
	}
}
