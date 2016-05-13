using UnityEngine;
using System.Collections;

public class HitScanWeapon : MonoBehaviour, IWeapon
{
    private float _damage = 1;
    [SerializeField]private Transform _muzzle; //shoots from here
    private RaycastHit _hit;
    private Vector3 _shootDirection;
    private float _gunRange = 40;
    private float _reloadTime = 5;

    void Update()
    {
        _shootDirection = _muzzle.TransformDirection(Vector3.forward); //the direction the player is facing
    }

    public void Shoot()
    {
        if (Physics.Raycast(_muzzle.transform.position, _shootDirection, _gunRange))
        {
            _hit.transform.SendMessage("ApplyDamage", _damage, SendMessageOptions.DontRequireReceiver); //Call the method Apply Damage in the gameobject that is hit
            GameObject muzzleFlash = ObjectPool.instance.GetObjectForType(Tags.MUZZLEFLASH, false);
            muzzleFlash.transform.position = _muzzle.transform.position;

            GameObject hitEffect = ObjectPool.instance.GetObjectForType(Tags.HITEFFECT, false);
            hitEffect.transform.position = _hit.transform.position;
        }
    }

    public float Reload()
    {
        return _reloadTime;
    }

}