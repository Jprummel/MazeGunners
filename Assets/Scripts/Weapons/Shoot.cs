using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    private bool _isReloading;
    private HitScanWeapon _hitScanWeapon;

	// Use this for initialization
	void Start () 
    {
        _hitScanWeapon = GetComponent<HitScanWeapon>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    public void ShootWeapon()
    {
        if (_isReloading == false)
        {
            _hitScanWeapon.Shoot();
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        _isReloading = true;
        yield return new WaitForSeconds(_hitScanWeapon.Reload());
        _isReloading = false;
    }

}
