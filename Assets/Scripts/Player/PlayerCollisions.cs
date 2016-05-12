using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {

    [SerializeField]private GameObject _player;

    void OnCollisionEnter(Collision coll)
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            //Get damage
            _player.SetActive(false);
        }

        if (other.tag == "PickUp")
        {
            //Pickup effect
        }
    }
}
