using UnityEngine;
using System.Collections;

public class PlayerInputs : MonoBehaviour {

    [SerializeField]private int             _playerNumber;
                    public  int             PlayerNumber
                    {
                        get
                        {
                            return _playerNumber;
                        }
                    }
                    private PauseGame       _pause;
                    private PlayerMovement  _movement;
                    private Shoot           _shoot;
                    private Animator        _animator;
    void Start()
    {
        _pause          = GetComponent<PauseGame>();
        _movement       = GetComponent<PlayerMovement>();
        _shoot          = GetComponent<Shoot>();
        _animator       = GetComponentInChildren<Animator>();
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
            if(leftY > 0.2 || leftY >= 0 && leftX !=0){
                inputVector = inputVector / 3;
            }
            _movement.Move(inputVector);
            Debug.Log("Moving on player " + _playerNumberString);
            if(leftY > 0) //moving forward i think otherwise switch with backward
            {
                if(_animator.GetCurrentAnimatorStateInfo(2).IsName("Idle"))
                {
                    _animator.SetBool("isMovingForward", true);
                }
                else
                {
                    _animator.SetBool("isMovingForward", false);
                }
                
                if(_animator.GetCurrentAnimatorStateInfo(2).IsName("StrafeRight"))
                {
                    _animator.SetBool("rightToForward", true);
                }
                else
                {
                    _animator.SetBool("rightToForward", false);
                }

                if (_animator.GetCurrentAnimatorStateInfo(2).IsName("StrafeLeft"))
                {
                    _animator.SetBool("leftToForward", true);
                }
                else
                {
                    _animator.SetBool("leftToForward", false);
                }

                if (_animator.GetCurrentAnimatorStateInfo(2).IsName("MovingBackward"))
                {
                    _animator.SetBool("backwardToForward", true);
                }
                else
                {
                    _animator.SetBool("backwardToForward", false);
                }
            }

            else if (leftY < 0) //moving backward i think otherwise switch with forward
            {
                if (_animator.GetCurrentAnimatorStateInfo(2).IsName("Idle"))
                {
                    _animator.SetBool("isMovingBackward", true);
                }
                else
                {
                    _animator.SetBool("isMovingBackward", false);
                }

                if (_animator.GetCurrentAnimatorStateInfo(2).IsName("StrafeRight"))
                {
                    _animator.SetBool("rightToBackward", true);
                }
                else
                {
                    _animator.SetBool("rightToBackward", false);
                }

                if (_animator.GetCurrentAnimatorStateInfo(2).IsName("StrafeLeft"))
                {
                    _animator.SetBool("leftToBackward", true);
                }
                else
                {
                    _animator.SetBool("leftToBack", false);
                }

                if (_animator.GetCurrentAnimatorStateInfo(2).IsName("MovingForward"))
                {
                    _animator.SetBool("backwardToBackward", true);
                }
                else
                {
                    _animator.SetBool("backwardToBackward", false);
                }
            }

            if(leftX > 0) //moving right i think otherwise switch with left
            {
                if (_animator.GetCurrentAnimatorStateInfo(2).IsName("Idle"))
                {
                    _animator.SetBool("isMovingRight", true);
                }
                else
                {
                    _animator.SetBool("isMovingRight", false);
                }

                if (_animator.GetCurrentAnimatorStateInfo(2).IsName("MovingForward"))
                {
                    _animator.SetBool("forwardToRight", true);
                }
                else
                {
                    _animator.SetBool("forwardToRight", false);
                }

                if (_animator.GetCurrentAnimatorStateInfo(2).IsName("StrafeLeft"))
                {
                    _animator.SetBool("leftToRight", true);
                }
                else
                {
                    _animator.SetBool("leftToRight", false);
                }

                if (_animator.GetCurrentAnimatorStateInfo(2).IsName("MovingBackward"))
                {
                    _animator.SetBool("backwardToRight", true);
                }
                else
                {
                    _animator.SetBool("backwardToRight", false);
                }
            }

            else if (leftX < 0) //moving left i think otherwise switch with right
            {
                if (_animator.GetCurrentAnimatorStateInfo(2).IsName("Idle"))
                {
                    _animator.SetBool("isMovingBackward", true);
                }
                else
                {
                    _animator.SetBool("isMovingBackward", false);
                }

                if (_animator.GetCurrentAnimatorStateInfo(2).IsName("StrafeRight"))
                {
                    _animator.SetBool("rightToLeft", true);
                }
                else
                {
                    _animator.SetBool("rightToLeft", false);
                }

                if (_animator.GetCurrentAnimatorStateInfo(2).IsName("MovingForward"))
                {
                    _animator.SetBool("forwardToLeft", true);
                }
                else
                {
                    _animator.SetBool("forwardToLeft", false);
                }

                if (_animator.GetCurrentAnimatorStateInfo(2).IsName("MovingBackward"))
                {
                    _animator.SetBool("backwardToLeft", true);
                }
                else
                {
                    _animator.SetBool("backwardToLeft", false);
                }
            }
        }

        float rightX = Input.GetAxis(InputAxes.RIGHTX + _playerNumberString); //RIGHT ANALOG X AXIS
        float rightY = Input.GetAxis(InputAxes.RIGHTY + _playerNumberString); //RIGHT ANALOG X AXIS

        //if (rightX != 0)
        //{
            _movement.RotateX(rightX);
        //}

        //if (rightY != 0)
        //{
            _movement.RotateY(rightY);
        //}

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
            //_switchWeapon.PreviousWeapon();
        }
        if (Input.GetButtonDown(InputAxes.RB + _playerNumberString))
        {
            //_switchWeapon.NextWeapon();
        }

        //TRIGGERS
        float leftTrigger  = Input.GetAxis(InputAxes.LT + _playerNumberString);
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

        if (Input.GetButtonDown(InputAxes.BACK + _playerNumberString))
        {

        }

        //Idle
        if (!Input.anyKeyDown && leftY == 0 && leftX == 0)
        {

        }
    }
}
