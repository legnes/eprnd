using UnityEngine;
using System.Collections;

public class TitleTextController : MonoBehaviour {

	double totalTime = 0f;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1.0f;
		Cursor.visible = false;
		Color col = GetComponent<SpriteRenderer>().color;
		col[3] = 0f;
		GetComponent<SpriteRenderer>().color = col;
	}
	
	// Update is called once per frame
	void Update () {
		if(Random.Range (1,10000)%83 == 0){
			Vector3 rpos = new Vector3(Random.Range(-33,33),Random.Range (-33,33),0);
			Camera.main.transform.Translate(rpos);
		}
		if (totalTime > 2) {
			Color col = GetComponent<SpriteRenderer>().color;
			col[3] = 1f;
			GetComponent<SpriteRenderer>().color = col;
		}
		if (totalTime > 3.5 && !GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().Play ();
		if(totalTime > 10) {
			Color col = GetComponent<SpriteRenderer>().color;
			col[3] = 0f;
			GetComponent<SpriteRenderer>().color = col;
		}
		if(totalTime > 11.5 && Application.CanStreamedLevelBeLoaded (Application.loadedLevel + 1)) Application.LoadLevel(Application.loadedLevel + 1);

		totalTime += Time.deltaTime;
	}
}
