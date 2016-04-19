using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]private float               _moveSpeed;
                    private CharacterController _charController;

	void Start () 
    {
        _charController = GetComponent<CharacterController>();
	}

    public void Move(Vector3 moveDirection)
    {
        
        moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= _moveSpeed;

        _charController.Move(moveDirection * Time.deltaTime);
    }

    public void Rotate(Vector3 rotateVector)
    {
        rotateVector.x = Mathf.Clamp(rotateVector.x, -10,30);
        rotateVector = new Vector3(rotateVector.x, rotateVector.y, 0);
        transform.Rotate(rotateVector);
    }

}
