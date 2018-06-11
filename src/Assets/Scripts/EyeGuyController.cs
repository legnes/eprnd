using UnityEngine;
using System.Collections;

public class EyeGuyController : MonoBehaviour {

	// Movement
	// open
	public float maxSpeed = 30f;
	public bool facingRight = true;
	// closed
	public float teleDist = 8f;
	public float teleSpeed = 100f;
	public Vector3 lastValidPos;
	public bool badColliding = false;
	bool resetting = false;
	KeyBut[] keys = new KeyBut[26];
	Vector3 wallFix;

	// Shift mechanic
	public bool eyesClosed = false;
	public bool eyesTriggered = false;
	GameObject bigEye;
	Animator anim;
	float animTime = 1f;
	float animTimer = 0f;
	public Vector2 pushVec;

	// Camera stuff
	GameObject camra;
	CameraFollowController camScript;
	float camSmooth;

	// Eye animation
	Animator blinkAnim;
	
	// Use this for initialization
	void Start () {
		Time.timeScale = 1.0f;
		Cursor.visible = false;

		bigEye = GameObject.Find ("Eyes");
		anim = bigEye.GetComponent<Animator> ();

		camra = GameObject.Find ("Main Camera");
		camScript = (CameraFollowController)camra.GetComponent (typeof(CameraFollowController));
		camSmooth = camScript.smoothTime;

		blinkAnim = GetComponent<Animator> ();

		pushVec = new Vector2 (0f, 0f);
		wallFix = new Vector3 (0f, 0f, 0f);

		// Top Row
		keys [0] = new KeyBut (-75f, 20f, 30f, 10f, -85f, -65f);
		keys [1] = new KeyBut (-55f, 20f, 30f, 10f, -65f, -45f);
		keys [2] = new KeyBut (-35f, 20f, 30f, 10f, -45f, -25f);
		keys [3] = new KeyBut (-15f, 20f, 30f, 10f, -25f, -5f);
		keys [4] = new KeyBut (5f, 20f, 30f, 10f, -5f, 15f);
		keys [5] = new KeyBut (25f, 20f, 30f, 10f, 15f, 35f);
		keys [6] = new KeyBut (45f, 20f, 30f, 10f, 35f, 55f);
		keys [7] = new KeyBut (65f, 20f, 30f, 10f, 55f, 75f);
		keys [8] = new KeyBut (85f, 20f, 30f, 10f, 75f, 95f);
		keys [9] = new KeyBut (105f, 20f, 30f, 10f, 95f, 115f);
		// Middle Row
		keys [10] = new KeyBut (-70f, 0f, 10f, -10f, -80f, -60f);
		keys [11] = new KeyBut (-50f, 0f, 10f, -10f, -60f, -40f);
		keys [12] = new KeyBut (-30f, 0f, 10f, -10f, -40f, -20f);
		keys [13] = new KeyBut (-10f, 0f, 10f, -10f, -20f, 0f);
		keys [14] = new KeyBut (10f, 0f, 10f, -10f, 0f, 20f);
		keys [15] = new KeyBut (30f, 0f, 10f, -10f, 20f, 40f);
		keys [16] = new KeyBut (50f, 0f, 10f, -10f, 40f, 60f);
		keys [17] = new KeyBut (70f, 0f, 10f, -10f, 60f, 80f);
		keys [18] = new KeyBut (90f, 0f, 10f, -10f, 80f, 100f);
		// Bottom Row
		keys [19] = new KeyBut (-60f, -20f, -10f, -30f, -70f, -50f);
		keys [20] = new KeyBut (-40f, -20f, -10f, -30f, -50f, -30f);
		keys [21] = new KeyBut (-20f, -20f, -10f, -30f, -30f, -10f);
		keys [22] = new KeyBut (0f, -20f, -10f, -30f, -10f, 10f);
		keys [23] = new KeyBut (20f, -20f, -10f, -30f, 10f, 30f);
		keys [24] = new KeyBut (40f, -20f, -10f, -30f, 30f, 50f);
		keys [25] = new KeyBut (60f, -20f, -10f, -30f, 50f, 70f);
	}
	
	// For input detection
	void Update() {

		// Reset the scene if necessary
		//if (Input.GetButtonDown ("Reset"))
			//Application.LoadLevel (Application.loadedLevel);

		// Check if the eyes are triggered
		if (Input.GetButtonDown ("Eyes")) {
			// Register Trigger
			eyesClosed = !eyesClosed;
			eyesTriggered = true;

			// Cancel any motion underway
			Vector2 zilch;
			zilch.x = 0f; zilch.y = 0f;
			GetComponent<Rigidbody2D>().velocity = zilch;
		}

		// Close eyes, sense input...or open eyes and untrigger letters
		if (eyesClosed) {
			anim.SetBool("EyesClosed",true);
			camScript.smoothTime = 0f;

			if(Input.GetKeyDown(KeyCode.Q)) keys[0].trig = !keys[0].trig;
			if(Input.GetKeyDown(KeyCode.W)) keys[1].trig = !keys[1].trig;
			if(Input.GetKeyDown(KeyCode.E)) keys[2].trig = !keys[2].trig;
			if(Input.GetKeyDown(KeyCode.R)) keys[3].trig = !keys[3].trig;
			if(Input.GetKeyDown(KeyCode.T)) keys[4].trig = !keys[4].trig;
			if(Input.GetKeyDown(KeyCode.Y)) keys[5].trig = !keys[5].trig;
			if(Input.GetKeyDown(KeyCode.U)) keys[6].trig = !keys[6].trig;
			if(Input.GetKeyDown(KeyCode.I)) keys[7].trig = !keys[7].trig;
			if(Input.GetKeyDown(KeyCode.O)) keys[8].trig = !keys[8].trig;
			if(Input.GetKeyDown(KeyCode.P)) keys[9].trig = !keys[9].trig;
			if(Input.GetKeyDown(KeyCode.A)) keys[10].trig = !keys[10].trig;
			if(Input.GetKeyDown(KeyCode.S)) keys[11].trig = !keys[11].trig;
			if(Input.GetKeyDown(KeyCode.D)) keys[12].trig = !keys[12].trig;
			if(Input.GetKeyDown(KeyCode.F)) keys[13].trig = !keys[13].trig;
			if(Input.GetKeyDown(KeyCode.G)) keys[14].trig = !keys[14].trig;
			if(Input.GetKeyDown(KeyCode.H)) keys[15].trig = !keys[15].trig;
			if(Input.GetKeyDown(KeyCode.J)) keys[16].trig = !keys[16].trig;
			if(Input.GetKeyDown(KeyCode.K)) keys[17].trig = !keys[17].trig;
			if(Input.GetKeyDown(KeyCode.L)) keys[18].trig = !keys[18].trig;
			if(Input.GetKeyDown(KeyCode.Z)) keys[19].trig = !keys[19].trig;
			if(Input.GetKeyDown(KeyCode.X)) keys[20].trig = !keys[20].trig;
			if(Input.GetKeyDown(KeyCode.C)) keys[21].trig = !keys[21].trig;
			if(Input.GetKeyDown(KeyCode.V)) keys[22].trig = !keys[22].trig;
			if(Input.GetKeyDown(KeyCode.B)) keys[23].trig = !keys[23].trig;
			if(Input.GetKeyDown(KeyCode.N)) keys[24].trig = !keys[24].trig;
			if(Input.GetKeyDown(KeyCode.M)) keys[25].trig = !keys[25].trig;
		}
		else {
			anim.SetBool("EyesClosed",false);
			if(badColliding) {TriggerReset();}
			camScript.smoothTime = camSmooth;
			for (int i = 0; i < keys.Length; i++) keys[i].trig = false;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// Wait to finish animation
		if(eyesTriggered) {
			if(animTimer < animTime) {
				animTimer += Time.deltaTime;
				return;
			}
			else animTimer = 0f;
		}

		if (eyesClosed) {
			gameObject.layer = 10;
			FixedUpdateClosed ();
		}  else if (!eyesClosed && !resetting) {
			gameObject.layer = 12;
			FixedUpdateOpen ();
		}
	}
	
	void FixedUpdateClosed()
	{
		// Register eyes closed
		eyesTriggered = false;

		// Get current info
		Vector3 thePos = transform.position;
		Vector3 oldPos = thePos;

		// Avoid rollover (i.e. extant) collisions
		wallFix.Normalize ();
		transform.Translate (0.3f * wallFix);
		gameObject.layer = 12;
		gameObject.layer = 10;


		// Get triggered input, move
		for (int i = 0; i < keys.Length; i++) {
			if(keys[i].trig) {
				
				Vector3 dir = thePos - keys[i].center;
				bool xOverlap = thePos.x <= keys[i].right && thePos.x > keys[i].left;
				bool yOverlap = thePos.y <= keys[i].top && thePos.y > keys[i].bot;
				if(xOverlap && yOverlap) {
					if(Mathf.Abs(dir.x) < Mathf.Abs(dir.y) && dir.y != 0)
						thePos.y += teleDist * dir.y / Mathf.Abs(dir.y);
					else if(dir.x != 0) thePos.x += teleDist * dir.x / Mathf.Abs(dir.x);
				}
				else if(xOverlap && dir.y != 0) {
					thePos.y += teleDist * dir.y / Mathf.Abs(dir.y);}
				else if(yOverlap && dir.x != 0) {
					thePos.x += teleDist * dir.x / Mathf.Abs(dir.x);}
			}
			Vector3 theVel = (thePos - oldPos) * teleSpeed; 
			GetComponent<Rigidbody2D>().velocity = new Vector2(theVel.x+pushVec.x,theVel.y+pushVec.y);
		}
	}
	
	void FixedUpdateOpen()
	{

		// Register eyes opened
		eyesTriggered = false;

		// Get input
		float moveLR = Input.GetAxis ("Horizontal");
		float moveUD = Input.GetAxis ("Vertical");

		// Move
		GetComponent<Rigidbody2D>().velocity = new Vector2 (maxSpeed * moveLR, maxSpeed * moveUD);

		// Animate
		if (moveLR > 0 && !facingRight)
			Flip ();
		else if (moveLR < 0 && facingRight)
			Flip ();

		if (moveLR != 0f || moveUD != 0f)
			blinkAnim.SetBool ("Moving", true);
		else 
			blinkAnim.SetBool("Moving",false);

	}
	
	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void TriggerReset() {
		resetting = true;
		blinkAnim.SetTrigger ("UhOh");
		Invoke ("ResetCharacter",1);
	}

	void ResetCharacter() {
		transform.position = lastValidPos;
		resetting = false;
	}
	
	// Bug fix to ignore extant collisions when closing eyes
	//void OnCollisionEnter2D(Collision2D other) {
	//	if(other.gameObject.layer == 8 && !other.collider.isTrigger) {
	//		Vector2 norm = other.contacts[0].normal;
	//		norm.Normalize();
	//		if((norm.x<0 && facingRight) || norm.y>0 && !facingRight)
	//			wallFix.x += norm.x;
	//		wallFix.y += norm.y;
	//		//print (wallFix);
	//	}
	//}

	//void OnCollisionExit2D(Collision2D other) {
	//	if(other.gameObject.layer == 8 && !other.collider.isTrigger) {
	//		Vector2 norm = other.contacts[0].normal;
	//		if(Mathf.Abs(norm.x) > 0.01) wallFix.x = 0;
	//		if(Mathf.Abs(norm.y) > 0.01) wallFix.y = 0;
	//		//print (wallFix);
	//	}
	//}
}