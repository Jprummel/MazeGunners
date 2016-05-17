using UnityEngine;
using System.Collections;

public class HitScanWeapon : MonoBehaviour
{
    [SerializeField]private Transform _raycastOriginMuzzle; //shoots from here
    [SerializeField]private Transform _particleMuzzle;
    private RaycastHit _hit;
    private Vector3 _shootDirection;
    private float _gunRange = 40;
    private float _reloadTime = 5;
    private PlayerDeath _playerDeath;

    void Update()
    {
        _shootDirection = _raycastOriginMuzzle.TransformDirection(Vector3.forward); //the direction the player is facing
        _playerDeath = GetComponent<PlayerDeath>();
    }

    public void Shoot()
    {
        if (Physics.Raycast(_raycastOriginMuzzle.transform.position, _shootDirection, _gunRange) && _playerDeath.IsActive == true)
        {
            _hit.transform.SendMessage("Kill", SendMessageOptions.DontRequireReceiver); //Call the method Kill() in the gameobject that is hit
            GameObject muzzleFlash = ObjectPool.instance.GetObjectForType(ObjectPoolNames.MUZZLEFLASH, false);
            muzzleFlash.transform.position = _raycastOriginMuzzle.transform.position;

            GameObject hitEffect = ObjectPool.instance.GetObjectForType(ObjectPoolNames.HITEFFECT, false);
            hitEffect.transform.position = _hit.transform.position;
        }
    }

    public float Reload()
    {
        return _reloadTime;
    }

}