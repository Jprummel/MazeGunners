using UnityEngine;
using System.Collections;

public class BoostPad : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        other.SendMessage("SpeedUp", SendMessageOptions.DontRequireReceiver);
    }

    void OnTriggerExit(Collider other)
    {
        other.SendMessage("SlowDown", SendMessageOptions.DontRequireReceiver);
    }
}
