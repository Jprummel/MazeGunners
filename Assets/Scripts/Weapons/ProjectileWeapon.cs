using UnityEngine;
using System.Collections;

public class ProjectileWeapon : MonoBehaviour, IWeapon
{

    [SerializeField]private Transform _muzzle; //shoots from here
    private float _randomAngle;
    private float _randomBounds = 1.5f;
    private float _reloadTime = 1;

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        /*if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }*/
	}

    public void Shoot()
    {
        _randomAngle = Random.Range(-_randomBounds, _randomBounds);
        Quaternion rotation = Quaternion.Euler(Vector3.up * _muzzle.transform.rotation.eulerAngles.y);

        GameObject muzzleFlash = ObjectPool.instance.GetObjectForType(ObjectPoolNames.MUZZLEFLASH, false);
        muzzleFlash.transform.position = _muzzle.transform.position;

        GameObject bullet = ObjectPool.instance.GetObjectForType(ObjectPoolNames.BULLET, false);
        bullet.transform.position = _muzzle.transform.position;
        bullet.transform.rotation = rotation;
        bullet.transform.Rotate(_randomAngle, _randomAngle, 0);
    }

    public float Reload()
    {
        return _reloadTime;
    }
}
