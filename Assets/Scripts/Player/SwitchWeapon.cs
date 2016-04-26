using UnityEngine;
using System.Collections;

public class SwitchWeapon : MonoBehaviour {

    private IWeapon _currentWeapon;
    public IWeapon CurrentWeapon
    {
        get
        {
            return _currentWeapon;
        }
    }
    private HitScanWeapon _hitScanWeapon;
    private ProjectileWeapon _projectileWeapon;

    private int _currentWeaponIndex;
    private int _minWeaponIndex = 0;
    private int _maxWeaponIndex = 1; //number of weapons -1

	// Use this for initialization
	void Start () 
    {
        _hitScanWeapon = GetComponent<HitScanWeapon>();
        _projectileWeapon = GetComponent<ProjectileWeapon>();
        _currentWeapon = _hitScanWeapon;
	}
	
	// Update is called once per frame
	void Update () 
    {
        WeaponSwitch();
	}

    void WeaponSwitch()
    {
        switch (_currentWeaponIndex)
        {
            case 0:
                _currentWeapon = _hitScanWeapon;
                break;
            case 1:
                _currentWeapon = _projectileWeapon;
                break;
        }

        if (_currentWeaponIndex < _minWeaponIndex)
        {
            _currentWeaponIndex = _maxWeaponIndex;
        }
        else if (_currentWeaponIndex > _maxWeaponIndex)
        {
            _currentWeaponIndex = _minWeaponIndex;
        }
    }

    public void NextWeapon()
    {
        _currentWeaponIndex++;
    }

    public void PreviousWeapon()
    {
        _currentWeaponIndex--;
    }

    /*public void ShootWeapon()
    {
        _currentWeapon.Shoot();
    }*/
}
