using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == Tags.PICKUP)
        {
            //Powerup function here
            this.gameObject.SendMessageUpwards("ActivateXRay", SendMessageOptions.DontRequireReceiver);
        }

        else if(other.gameObject.tag == Tags.BOOSTPAD)
        {
            this.gameObject.SendMessageUpwards("Boost", SendMessageOptions.DontRequireReceiver);
        }
    }
}
