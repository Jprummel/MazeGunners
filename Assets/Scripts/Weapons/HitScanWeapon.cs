using UnityEngine;
using System.Collections;

public class HitScanWeapon : MonoBehaviour, IWeapon
{
    //private float _damage = 1;
    //[SerializeField]private GameObject _crosshair; //use for crosshair
    private RaycastHit _hit;
    private Vector3 _shootDirection;

    private float _gunRange = 40;
    private float _reloadTime = 5;
    private float _reloadTimeStamp = 0;

    void Update()
    {
        _shootDirection = transform.TransformDirection(Vector3.forward); //the direction the player is facing
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (Physics.Raycast(transform.position, _shootDirection, _gunRange) && Time.time >= _reloadTimeStamp + _reloadTime) //if a game object is in front of player but within gunrange units of it trigger a hit
        {
            //_hit.transform.SendMessage("ApplyDammage", _damage, SendMessageOptions.DontRequireReceiver); //Call the method Apply Damage in the gameobject that is hit
            _reloadTimeStamp = Time.time;
            Debug.Log("hit");
            //Debug.DrawRay(transform.position, _shootDirection, Color.green);
        }
    }
}