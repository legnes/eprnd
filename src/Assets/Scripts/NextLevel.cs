using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {
	public bool last;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(last) Application.LoadLevel(1);
		else if(other.gameObject.layer == 12 && Application.CanStreamedLevelBeLoaded (Application.loadedLevel + 1)) Application.LoadLevel(Application.loadedLevel + 1);
	}
}
