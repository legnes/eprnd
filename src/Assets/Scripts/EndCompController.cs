using UnityEngine;
using System.Collections;

public class EndCompController : MonoBehaviour {
	
	Animator anim;
	Animator textAnim;
	public GameObject cmpT;
	public GameObject cam;
	bool disp = false;
	bool pressable = false;
	double timeSum = 0.0;

	CameraFollowController camfollow;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		textAnim = cmpT.GetComponent<Animator> ();
		camfollow = (CameraFollowController)cam.GetComponent (typeof(CameraFollowController));
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
			camfollow.cameraTarget = cmpT;
			Camera.main.fieldOfView = 140;
			Color col = cmpT.GetComponent<SpriteRenderer>().color;
			col[3] = 1f;
			cmpT.GetComponent<SpriteRenderer>().color = col;
			disp = true;
			pressable = false;
			textAnim.SetTrigger ("end");
		}
		if (disp) {
			if(Random.Range (1,10000)%33 == 0 && timeSum <= 30){
				Vector3 rpos = new Vector3(Random.Range(-33,33),Random.Range (-33,33),0);
				Camera.main.transform.Translate(rpos);
			}
			if(timeSum > 20) {
				if(Random.Range (1,10000)%45 == 0){
					Vector3 rtpos = new Vector3(Random.Range(-1,1),Random.Range (-1,1),0);
					cmpT.transform.Translate(rtpos);
				}
			}
			if(timeSum > 29)
				Application.LoadLevel(1);
			timeSum  += Time.deltaTime;
		}
	}
}