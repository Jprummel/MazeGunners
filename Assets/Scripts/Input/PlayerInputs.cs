﻿using UnityEngine;
using System.Collections;

public class PlayerInputs : MonoBehaviour {

    [SerializeField]private int             _playerNumber;
                    private PauseGame       _pause;
                    private PlayerMovement  _movement;
                    private Shoot           _shoot;
    void Start()
    {
        _pause      = GetComponent<PauseGame>();
        _movement   = GetComponent<PlayerMovement>();
        _shoot      = GetComponent<Shoot>();
    }

	void Update () {
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

        Vector3 inputVector = new Vector3(leftX,0, -leftY);

        if (leftX != 0 || leftY != 0)
        {
            _movement.Move(inputVector);
            Debug.Log("Moving on player " + _playerNumberString);
        }

        float rightX = Input.GetAxis(InputAxes.RIGHTX + _playerNumberString); //RIGHT ANALOG X AXIS
        float rightY = Input.GetAxis(InputAxes.RIGHTY + _playerNumberString); //RIGHT ANALOG X AXIS

        if (rightX != 0)
        {
            _movement.RotateX(100,rightX);
        }

        if (rightY != 0)
        {
            _movement.RotateY(150,rightY);
        }

        if (Input.GetButtonDown(InputAxes.L3 + _playerNumberString))
        {

        }

        if (Input.GetButtonDown(InputAxes.R3 + _playerNumberString))
        {

        }

        //FACE BUTTONS
        if (Input.GetButtonDown(InputAxes.A + _playerNumberString))
        {
            Debug.Log("Pressed A on player " + _playerNumberString);
        }

        if (Input.GetButtonDown(InputAxes.B + _playerNumberString))
        {

        }

        if (Input.GetButtonDown(InputAxes.X + _playerNumberString))
        {
         
        }

        if (Input.GetButtonDown(InputAxes.Y + _playerNumberString))
        {

        }

        //BUMPERS & TRIGGERS

        //BUMPERS
        if (Input.GetButton(InputAxes.LB + _playerNumberString))
        {

        }
        if (Input.GetButtonDown(InputAxes.RB + _playerNumberString))
        {

        }

        //TRIGGERS
        float leftTrigger  = Input.GetAxis(InputAxes.LT + _playerNumberString);
        float rightTrigger = Input.GetAxis(InputAxes.RT + _playerNumberString);

        if (leftTrigger > 0)
        {

        }
        if (rightTrigger > 0)
        {
            _shoot.IShoot();
        }

        //START & BACK
        if (Input.GetButtonDown(InputAxes.START + _playerNumberString))
        {
            _pause.PauseToggle();
        }

        if (Input.GetButtonDown(InputAxes.BACK + _playerNumberString))
        {

        }

        //Idle
        if (!Input.anyKeyDown && leftY == 0 && leftX == 0)
        {

        }
    }
}
