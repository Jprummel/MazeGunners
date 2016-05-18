using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    private bool _isReloading;
    private HitScanWeapon _hitScanWeapon;
    private float _reloadTime = 5;
    public float ReloadTime
    {
        get
        {
            return _reloadTime;
        }
    }
    private float _oldReloadTime;
    private float _fillSpeed = 0.1f;

	// Use this for initialization
	void Start () 
    {
        _hitScanWeapon = GetComponent<HitScanWeapon>();
        _oldReloadTime = _reloadTime;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetMouseButtonDown(0))
        {
            ShootWeapon();
        }
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
        _reloadTime = 0;
        while (_isReloading && _reloadTime < 5)
        {
            yield return new WaitForSeconds(_fillSpeed);
            _reloadTime += _fillSpeed;
        }
        _isReloading = false;
        _reloadTime = _oldReloadTime;
    }

}
