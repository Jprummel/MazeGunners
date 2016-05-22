using UnityEngine;
using System.Collections;

public class PlayerInputs : MonoBehaviour
{

    [SerializeField]
    private int _playerNumber;
    public int PlayerNumber
    {
        get
        {
            return _playerNumber;
        }
    }
    private PauseGame _pause;
    private PlayerMovement _movement;
    private Shoot _shoot;
    private Animator _animator;
    void Start()
    {
        _pause = GetComponent<PauseGame>();
        _movement = GetComponent<PlayerMovement>();
        _shoot = GetComponent<Shoot>();
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        XboxControllerInput();
    }


    void XboxControllerInput()
    {
        string _playerNumberString = _playerNumber.ToString();
        //DPAD
        float dpadX = Input.GetAxis(InputAxes.DPADX + _playerNumberString); //DPAD X AXIS

        if (dpadX > 0)
        {

        }
        else if (dpadX < 0)
        {

        }

        float dpadY = Input.GetAxis(InputAxes.DPADY + _playerNumberString); //DPAD Y AXIS

        if (dpadY > 0)
        {

        }
        else if (dpadY < 0)
        {

        }

        //ANALOG STICKS
        float leftX = Input.GetAxis(InputAxes.LEFTX + _playerNumberString); //LEFT ANALOG X AXIS
        float leftY = Input.GetAxis(InputAxes.LEFTY + _playerNumberString); //LEFT ANALOG Y AXIS

        Vector3 inputVector = new Vector3(leftX, 0, -leftY);

        //Idle
        if (!Input.anyKeyDown && leftY == 0 && leftX == 0)
        {
            //AnimStateHandler.AnimStateGeneral(0);
        }

        if (leftX != 0 || leftY != 0)
        {
            if (leftY > 0.2 || leftY >= 0 && leftX != 0)
            {
                inputVector = inputVector / 3;
            }
        }
        _movement.Move(inputVector);
        Debug.Log("Moving on player " + _playerNumberString);
        if (leftY < 0) //moving forward i think otherwise switch with backward
        {
            AnimStateHandler.AnimStateGeneral(1);
        }

        else if (leftY > 0) //moving backward i think otherwise switch with forward
        {
           AnimStateHandler.AnimStateGeneral(2);
        }
        else if (leftY == 0)
        {

        }

        if (leftX > 0) //moving right i think otherwise switch with left
        {
            AnimStateHandler.AnimStateGeneral(3);
        }

        else if (leftX < 0) //moving left i think otherwise switch with right
        {
            AnimStateHandler.AnimStateGeneral(4);
        }
        else if (leftX == 0)
        {

        }

        float rightX = Input.GetAxis(InputAxes.RIGHTX + _playerNumberString); //RIGHT ANALOG X AXIS
        float rightY = Input.GetAxis(InputAxes.RIGHTY + _playerNumberString); //RIGHT ANALOG X AXIS

        if (rightX != 0)
        {
            Debug.Log("Right");
            _movement.RotateX(rightX);
        }

        if (rightY != 0)
        {
            Debug.Log("Left");
            _movement.RotateY(rightY);
        }

        //TRIGGERS
        float leftTrigger = Input.GetAxis(InputAxes.LT + _playerNumberString);
        float rightTrigger = Input.GetAxis(InputAxes.RT + _playerNumberString);

        if (leftTrigger > 0)
        {

        }
        if (rightTrigger > 0)
        {
            _shoot.ShootWeapon();
        }

        //START & BACK
        if (Input.GetButtonDown(InputAxes.START + _playerNumberString))
        {
            _pause.PauseToggle();
        }
    }
}

