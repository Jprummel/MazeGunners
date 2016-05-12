using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    public delegate void PickupAction();
    public static event PickupAction OnPickup;

    void XRayVisionPickup()
    {
        if (OnPickup != null)
        {
            OnPickup();
        }
    }
}
