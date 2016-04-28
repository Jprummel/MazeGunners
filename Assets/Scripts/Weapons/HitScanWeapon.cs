using UnityEngine;
using System.Collections;

public class HitScanWeapon : MonoBehaviour, IWeapon
{
    //private float _damage = 1;
    //[SerializeField]private GameObject _crosshair; //use for crosshair
    private RaycastHit _hit;
    private Vector3 _shootDirection;
    private float _gunRange = 40;

    void Update()
    {
        _shootDirection = transform.TransformDirection(Vector3.forward); //the direction the player is facing
    }

    public void Shoot()
    {
        if (Physics.Raycast(transform.position, _shootDirection, _gunRange))
        {
            //_hit.transform.SendMessage("ApplyDamage", _damage, SendMessageOptions.DontRequireReceiver); //Call the method Apply Damage in the gameobject that is hit
            //Debug.DrawRay(transform.position, _shootDirection, Color.green);
            Debug.Log("hit");
        }
    }

}