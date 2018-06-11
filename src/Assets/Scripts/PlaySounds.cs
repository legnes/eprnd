using UnityEngine;
using System.Collections;

public class PlaySounds : MonoBehaviour {

	public AudioClip[] openSoundtrack;
	public AudioClip[] closedSoundtrack;

	int lastPlayed;

	EyeGuyController egcScript;

	// Use this for initialization
	void Start () {
		egcScript = (EyeGuyController)GameObject.Find ("EyeGuy").GetComponent (typeof(EyeGuyController));

		GetComponent<AudioSource>().clip = openSoundtrack [Random.Range (0, openSoundtrack.Length)];
		GetComponent<AudioSource>().Play ();
		lastPlayed = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (egcScript.eyesClosed)
			PlayEyesClosed ();
		else if (!egcScript.eyesClosed)
			PlayEyesOpen();
	
	}

	void PlayEyesClosed() {
		// Fade in
		if (GetComponent<AudioSource>().volume < 1)
			GetComponent<AudioSource>().volume += 1 * Time.deltaTime;


		if(GetComponent<AudioSource>().isPlaying && lastPlayed == 0) return;
		GetComponent<AudioSource>().clip = closedSoundtrack [Random.Range (0, closedSoundtrack.Length)];
		GetComponent<AudioSource>().Play ();
		GetComponent<AudioSource>().volume = 0.3f;

		lastPlayed = 0;
	}

	void PlayEyesOpen() {
		GetComponent<AudioSource>().volume = 1;
		if(GetComponent<AudioSource>().isPlaying && lastPlayed == 1) return;
		GetComponent<AudioSource>().clip = openSoundtrack [Random.Range (0, openSoundtrack.Length)];
		GetComponent<AudioSource>().Play ();

		lastPlayed = 1;
	}
}
