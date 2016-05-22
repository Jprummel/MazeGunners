using UnityEngine;
using System.Collections;

public class XRayVisionPowerup: MonoBehaviour
{
    private RaycastHit _hit;
    private Vector3 _direction;
    private float _wallHackRange = 40;
    private float _xRayVisionDuration = 5;

    private Transform _lastHit;
    private Transform _currentHit;
    private Camera _camera;
    private int _oldMask;
    private bool _isClearingWall = false;
    private bool _isXRayActive = false;

    void Start()
    {
        _lastHit = transform;
        _camera = gameObject.GetComponentInChildren<Camera>();
        _oldMask = _camera.cullingMask;
    }

    void Update()
    {
        if(_isXRayActive == true)
        {
            LookForWall();
        }
    }

    void LookForWall()
    {
        _direction = transform.TransformDirection(Vector3.forward); //the direction the object is facing
        if (Physics.Raycast(transform.position, _direction, out _hit, _wallHackRange))
        {
            _currentHit = _hit.transform;
            if ( _lastHit != _currentHit)
            {
                _lastHit.SendMessage("OpaqueWall", SendMessageOptions.DontRequireReceiver); //call the method ClearWall() in the gameobject that was previously hit
                _lastHit = _currentHit;
            }

            if (_hit.transform.tag == Tags.WALL && !_isClearingWall)
            {
                
                _hit.transform.SendMessage("ClearWall", SendMessageOptions.DontRequireReceiver); //call the method ClearWall() in the gameobject that is hit
                _camera.cullingMask &= ~(1 << 8);
                _isClearingWall = true;
            }

            if(_hit.transform.tag != Tags.WALL)
            {
                _camera.cullingMask = _oldMask;
                _isClearingWall = false;
            }
        }
    }

    void ActivateXRay()
    {
        _isXRayActive = true;
        StartCoroutine(XRayVision());
    }

    IEnumerator XRayVision()
    {
        yield return new WaitForSeconds(_xRayVisionDuration);
        _isXRayActive = false;
    }

}