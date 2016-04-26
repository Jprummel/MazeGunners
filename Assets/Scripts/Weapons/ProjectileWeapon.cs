using UnityEngine;
using System.Collections;

public class ProjectileWeapon : MonoBehaviour, IWeapon
{

    [SerializeField]private GameObject _muzzle; //shoots from here

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
        Quaternion rotation = Quaternion.Euler(Vector3.up * _muzzle.transform.rotation.eulerAngles.y);

        GameObject bullet = ObjectPool.instance.GetObjectForType(Tags.BULLET, false);
        bullet.transform.position = _muzzle.transform.position;
        bullet.transform.rotation = rotation;
    }
}
