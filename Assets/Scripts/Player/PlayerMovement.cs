using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]private float               _moveSpeed;
                    private CharacterController _charController;
                    private Transform           _playerSpine;
                    private Transform           _camera;
                    private Animator            _animator;
                    private bool                _isBoosting = false;
                    private float               _rotationX;
                    private float               _rotationY;
    [SerializeField]private float               _minY, _maxY;
                    private float               _speedUpAmount = 1;
	[SerializeField]private float 				_cameraSensitivity = 150;
                    private float               _speedBoostDuration = 3;
                    private float               _oldMoveSpeed;
	void Start () 
    {
        _camera = transform.Find("PlayerContainer/Camera");
        _playerSpine = transform.Find("PlayerContainer/Heavyrat/pasted__Character2_Reference/pasted__Character2_Hips/pasted__Character2_Spine");
        _charController = GetComponent<CharacterController>();
        _oldMoveSpeed = _moveSpeed;
        _animator = transform.Find("PlayerContainer/Heavyrat").GetComponent<Animator>();
	}

    void Update()
    {
        UpdateRotation();
    }

    public void Move(Vector3 moveDirection)
    {
        
        moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
        moveDirection = transform.TransformDirection(moveDirection);
        //moveDirection *= _moveSpeed;

        _charController.Move(moveDirection *_moveSpeed * Time.deltaTime);
    }

    public void RotateX(float value)
    {
		_rotationX += (Time.deltaTime * _cameraSensitivity) * value;
    }

    public void RotateY(float value)
    {
		_rotationY += (Time.deltaTime * _cameraSensitivity) * value;
        _rotationY = Mathf.Clamp(_rotationY, -80, 89);
    }

    void UpdateRotation()
    {
        Vector3 playerRotation = new Vector3(0, _rotationX);
        Vector3 lookingRotation = new Vector3(_rotationY,_rotationX);
        transform.eulerAngles = playerRotation;
        _playerSpine.eulerAngles = lookingRotation;
        _camera.eulerAngles = lookingRotation;
    }

    void Boost()
    {
        if (_moveSpeed < (_moveSpeed + _speedUpAmount) && _isBoosting == false)
        {
            _moveSpeed += _speedUpAmount;
            _isBoosting = true;
            StartCoroutine(SpeedBoostDelay());
        }
    }

    IEnumerator SpeedBoostDelay()
    {
        _animator.speed = 1.4f;
        yield return new WaitForSeconds(_speedBoostDuration);
        _moveSpeed = _oldMoveSpeed;
        _isBoosting = false;
        _animator.speed = 1.0f;
    }

}
