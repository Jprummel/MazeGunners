using UnityEngine;
using System.Collections;

public class WallHack: MonoBehaviour
{
    private RaycastHit _hit;
    private Vector3 _direction;
    private float _wallHackRange = 40;
    private Transform _lastHit;
    private Transform _currentHit;

    void Start()
    {
        _lastHit = transform;
    }

    void Update()
    {
        
        LookForWall();
    }

    void LookForWall()
    {
        _direction = transform.TransformDirection(Vector3.forward); //the direction the object is facing
        if (Physics.Raycast(transform.position, _direction, out _hit, _wallHackRange))
        {
            _currentHit = _hit.transform;
            if ( _lastHit != _currentHit)
            {
                _lastHit.SendMessage("OpaqueWall", SendMessageOptions.DontRequireReceiver);
                _lastHit = _currentHit;
            }

            if (_hit.transform.tag == "Wall")
            {
                _hit.transform.SendMessage("ClearWall", SendMessageOptions.DontRequireReceiver); //call the method ClearWall() in the gameobject that is hit
            }
            //Debug.Log("hit");
        }
    }

}