using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    private bool _isReloading;
    private SwitchWeapon _switchWeapon;

	// Use this for initialization
	void Start () 
    {
        _switchWeapon = GetComponent<SwitchWeapon>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    /*if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }*/
	}

    public void ShootWeapon()
    {
        if (_isReloading == false)
        {
            _switchWeapon.CurrentWeapon.Shoot();
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        _isReloading = true;
        yield return new WaitForSeconds(_switchWeapon.CurrentWeapon.Reload());
        _isReloading = false;
    }

}
