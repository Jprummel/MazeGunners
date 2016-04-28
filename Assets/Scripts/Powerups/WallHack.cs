using UnityEngine;
using System.Collections;

public class WallHack: MonoBehaviour
{
    private RaycastHit _hit;
    private Vector3 _direction;
    private float _wallHackRange = 10;

    void Start()
    {

    }

    void Update()
    {
        _direction = transform.TransformDirection(Vector3.forward); //the direction the object is facing
        LookForWall();
    }

    void LookForWall()
    {
        if (Physics.Raycast(transform.position, _direction, out _hit, _wallHackRange))
        {
            if (_hit.transform.tag == "Wall")
            {
                _hit.transform.SendMessage("ClearWall", SendMessageOptions.DontRequireReceiver); //call the method ClearWall() in the gameobject that is hit
            }
            Debug.Log("hit");
        }
    }

}