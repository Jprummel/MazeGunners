using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == Tags.PICKUP)
        {
            this.gameObject.SendMessageUpwards("ActivateXRay", SendMessageOptions.DontRequireReceiver);
            Destroy(other.gameObject);
        }

        else if(other.gameObject.tag == Tags.BOOSTPAD)
        {
            this.gameObject.SendMessageUpwards("Boost", SendMessageOptions.DontRequireReceiver);
        }
    }
}
