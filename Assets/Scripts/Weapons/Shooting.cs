using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    private bool _isReloading;
    private float _reloadTime = 5;
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

    public void Shoot()
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
        yield return new WaitForSeconds(_reloadTime);
        _isReloading = false;
    }

}
