using UnityEngine;
using System.Collections;

public class CompController : MonoBehaviour {
	
	Animator anim;
	public GameObject cmpT;
	bool disp = false;
	bool pressable = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(!disp) anim.SetBool("showEnt",true);
		pressable = true;
	}

	void OnTriggerExit2D(Collider2D other) {
		if(!disp) anim.SetBool("showEnt",false);
		pressable = false;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Comp") && pressable) {
			anim.SetBool ("showEnt",false);
			Color col = cmpT.GetComponent<SpriteRenderer>().color;
			col[3] = 1f;
			cmpT.GetComponent<SpriteRenderer>().color = col;
			disp = true;
			pressable = false;
		}
	}
}
