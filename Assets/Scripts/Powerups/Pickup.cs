using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    public delegate void PickupAction();
    public static event PickupAction OnPickup;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void XRayVisionPickup()
    {
        if (OnPickup != null)
        {
            OnPickup();
        }
    }
}
