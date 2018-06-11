using UnityEngine;
using System.Collections;

public class MarvinController : MonoBehaviour {

	int mcount = 0;
	Animator anim;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1.0f;
		Cursor.visible = false;
		anim = GetComponent<Animator> ();
		anim.SetInteger("MarvinCount",mcount);
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown) {
			//mcount++;
			//anim.SetInteger("MarvinCount",mcount);
			if(Application.CanStreamedLevelBeLoaded (Application.loadedLevel + 1)) Application.LoadLevel(Application.loadedLevel + 1);
		}
		//if(mcount > 7) Application.LoadLevel(Application.loadedLevel + 1);
	}
}
