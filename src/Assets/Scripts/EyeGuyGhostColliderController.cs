using UnityEngine;
using System.Collections;

public class EyeGuyGhostColliderController : MonoBehaviour {

	bool collisionDetected = false;
	Vector3 lvp;

	CircleCollider2D[] colliders;
	bool rescale = true;
	bool push = false;

	EyeGuyController egcScript;

	// Use this for initialization
	void Start () {

		egcScript = (EyeGuyController)transform.parent.gameObject.GetComponent (typeof(EyeGuyController));
		colliders = transform.parent.gameObject.GetComponents<CircleCollider2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		// Reset Colliders
		if(!rescale && !egcScript.eyesClosed) {
			foreach(CircleCollider2D cCol in colliders)
				cCol.radius /= 0.2f;
			rescale = true;
		}

		// Reset Push (OWall)
		if(push && !egcScript.eyesClosed) {
			Vector2 pv = new Vector2(0f,0f);
			egcScript.pushVec = pv;
			push = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {

		// BWall stuff
		if(other.gameObject.layer == 13 && !collisionDetected && egcScript.eyesClosed) {
			foreach(CircleCollider2D cCol in colliders)
				cCol.radius *= 0.2f;
			rescale = false;
			print ("okay");
			//collisionDetected = true;
		}

		// OWall stuff
		if(other.gameObject.layer == 14 && !collisionDetected && egcScript.eyesClosed) {
			push = true;

			int sign;
			if(egcScript.facingRight) sign = 1;
			else sign = -1;

			Vector2 pushVec = transform.parent.GetComponent<Rigidbody2D>().velocity;
			if(pushVec.x != 0) pushVec.y += egcScript.teleSpeed * 10 * sign;
			else if(pushVec.y != 0) pushVec.x += egcScript.teleSpeed * 10 * sign;
			egcScript.pushVec = pushVec;

			//collisionDetected = true;
		}

		// GWall eyes closed collision stuff
		if(other.gameObject.layer == 8 && !collisionDetected && egcScript.eyesClosed) {
			lvp = transform.position;

			Vector2 theVel = transform.parent.GetComponent<Rigidbody2D>().velocity;
			if(theVel.x != 0) {lvp.x -= 2 * theVel.x/Mathf.Abs (theVel.x);}
			if(theVel.y != 0) {lvp.y -= 2 * theVel.y/Mathf.Abs (theVel.y);}

			egcScript.lastValidPos = lvp;
			
			collisionDetected = true;
			egcScript.badColliding = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if(collisionDetected) {
			collisionDetected = false;
			egcScript.badColliding = false;
		}
	}
}
