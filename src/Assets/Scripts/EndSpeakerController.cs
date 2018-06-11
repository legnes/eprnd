using UnityEngine;
using System.Collections;

public class EndSpeakerController : MonoBehaviour {
	
	public GameObject trgt;
	Vector3 pos;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1.0f;
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(trgt.transform.position.x < pos.x && !GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().Play ();
	}
}
