using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

	private bool paused;
	private float savedTimeScale;
	private float wide;
	private float tall;

	public GUISkin pmskin;

	// Use this for initialization
	void Start () {
		paused = false;
		wide = Screen.width;
		tall = Screen.height;

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Pause")) {
			paused = !paused;
			if(paused) PauseGame();
			else UnPauseGame();
		}
	}

	void OnGUI() {
		if(paused) {
			GUI.skin = pmskin;

			// Make a background box
			GUI.Box(new Rect(3f*wide/8f,tall/4f,wide/4f,tall/2f+(tall/20f)), "Paused");
		
			if(GUI.Button(new Rect(3f*wide/8f + (0.1f*wide/4f),3.5f*tall/10f,0.8f*wide/4f,tall/10f), "Continue")) {
				paused = false;
				UnPauseGame();
			}

			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect(3f*wide/8f + (0.1f*wide/4f),5f*tall/10,0.8f*wide/4f,tall/10f), "Reset Level")) {
				UnPauseGame ();
				Application.LoadLevel(Application.loadedLevel);
			}
		
			// Make the second button.
			if(GUI.Button(new Rect(3f*wide/8f + (0.1f*wide/4f),6.5f*tall/10f,0.8f*wide/4f,tall/10f), "Main Menu")) {
				UnPauseGame ();
				if(Application.CanStreamedLevelBeLoaded (1)) Application.LoadLevel(1);
			}
		}
	}

	void PauseGame() {
		savedTimeScale = Time.timeScale;
		Time.timeScale = 0f;
		//AudioListener.pause = true;
		Cursor.visible = true;
	}

	void UnPauseGame() {
		Time.timeScale = savedTimeScale;
		//AudioListener.pause = false;
		Cursor.visible = false;
	}
}
