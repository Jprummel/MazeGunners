using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour {
	[SerializeField]private List<GameObject> powerUps = new List<GameObject> ();
	// Use this for initialization
	void Start () {
		int randomInt = Random.Range (0, 100);
		if (randomInt >= 90) {//spawn a powerup
			float margin = 100 / powerUps.Count;
			randomInt = Random.Range (0, 100);
			for (int i = 0; i < powerUps.Count; i++) {
				if (randomInt >= margin * powerUps.Count - 1 && randomInt <= margin * powerUps.Count) {
					Debug.Log ("powerupChosen");
				}
			}

		}
	}
}
