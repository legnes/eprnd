using UnityEngine;
using System.Collections;

public class PreviousLevel : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D other)
	{
		print (other.gameObject.layer);
		if(other.gameObject.layer == 12 && Application.CanStreamedLevelBeLoaded (Application.loadedLevel - 1)) Application.LoadLevel(Application.loadedLevel - 1);
	}
}
