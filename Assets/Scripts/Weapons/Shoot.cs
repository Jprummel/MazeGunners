using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    private bool _isReloading;
    private HitScanWeapon _hitScanWeapon;
    private Animator _animator;
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

        _animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
    void Update() //<--- subject to removal
    {
	    if(Input.GetMouseButtonDown(0))
        {
            ShootWeapon();
            //_animator.SetBool("isMovingForward", true);
        }

        if(Input.GetMouseButtonUp(0))
        {
            //_animator.SetBool("isMovingForward", false);
        }
	}

    public void ShootWeapon()
    {
        if (_isReloading == false)
        {
            StartCoroutine(AnimHandling());
            _hitScanWeapon.Shoot();
            StartCoroutine(Reload());
        }
    }

    IEnumerator AnimHandling()
    {
        AnimStateHandler.AnimStateOverride(1);
        AnimStateHandler.ViewState(1);
        yield return new WaitForSeconds(0.3f);
        AnimStateHandler.AnimStateOverride(0);
        AnimStateHandler.ViewState(0);
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
