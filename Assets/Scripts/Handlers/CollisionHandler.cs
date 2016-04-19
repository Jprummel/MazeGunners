using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (this.tag == Tags.PLAYER && other.tag == Tags.BULLET)
        {
            //Die function here
        }

        if (this.tag == Tags.PLAYER && other.tag == Tags.PICKUP)
        {
            //Powerup function here
        }
    }
}
