using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIAmmo : MonoBehaviour {

    private Image _ammoImage;
    private Shoot _shoot;
    private PlayerInputs _playerInputs;
    private float _fillOffset;

	// Use this for initialization
	void Start () 
    {
        _shoot = GetComponent<Shoot>();
        _fillOffset = _shoot.ReloadTime;
        _playerInputs = GetComponent<PlayerInputs>();

        switch (_playerInputs.PlayerNumber)
        {
            case 0:
                break;
            case 1:
                _ammoImage = GameObject.Find("UIBulletP1").GetComponent<Image>();
                break;
            case 2:
                _ammoImage = GameObject.Find("UIBulletP2").GetComponent<Image>();
                break;
            case 3:
                _ammoImage = GameObject.Find("UIBulletP3").GetComponent<Image>();
                break;
            case 4:
                _ammoImage = GameObject.Find("UIBulletP4").GetComponent<Image>();
                break;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        _ammoImage.fillAmount = _shoot.ReloadTime /_fillOffset;
	}
}
