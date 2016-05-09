using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]private float               _moveSpeed;
                    private CharacterController _charController;
                    private Transform _playerArms;
                    private float _rotationX;
                    private float _rotationY;

	void Start () 
    {
        _playerArms = transform.Find("Arms");
        _charController = GetComponent<CharacterController>();
	}

    void Update()
    {
        UpdateRotation();
    }

    public void Move(Vector3 moveDirection)
    {
        
        moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= _moveSpeed;

        _charController.Move(moveDirection * Time.deltaTime);
    }

    public void RotateX(float rotationSpeed, float value)
    {
        _rotationX += Time.deltaTime * rotationSpeed * value;
    }

    public void RotateY(float camSensitivity, float value)
    {
        _rotationY += Time.deltaTime * camSensitivity * value;
        _rotationY = Mathf.Clamp(_rotationY, -30, 70);
    }

    void UpdateRotation()
    {
        Vector3 playerRotation = new Vector3(0, _rotationX);
        Vector3 armsRotation = new Vector3(_rotationY,_rotationX);
        transform.eulerAngles = playerRotation;
        _playerArms.eulerAngles = armsRotation;
    }

}
