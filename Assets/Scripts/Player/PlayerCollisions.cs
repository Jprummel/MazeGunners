using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {

    [SerializeField]private GameObject _player;
    private RoundData _roundData;

    void Start()
    {
        _roundData = GameObject.Find("PlayerChecker").GetComponent<RoundData>();
    }

    void OnCollisionEnter(Collision coll)
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            //Get damage
            _roundData.Remove(this.gameObject);
            _player.SetActive(false);
        }

        if (other.tag == "PickUp")
        {
            //Pickup effect
        }
    }
}
