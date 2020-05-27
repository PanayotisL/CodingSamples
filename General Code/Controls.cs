using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Controls : MonoBehaviour
{

    private float DpadHorizX, DpadHorizY;
    public static bool IsLeft, IsRight, IsUp, IsDown;
    private float _LastX, _LastY;
    private bool rtaxis = false, ltaxis = false;

    void Update()
    {

       
        //Controller Inputs
        if (Input.GetKeyDown("joystick button 0"))
        {
            Debug.Log("A");
        }
        if (Input.GetKeyDown("joystick button 1"))
        {
            Debug.Log("B");
        }
        if (Input.GetKeyDown("joystick button 2"))
        {
            Debug.Log("X");
        }
        if (Input.GetKeyDown("joystick button 3"))
        {
            Debug.Log("Y");
        }
        if (Input.GetKeyDown("joystick button 4"))
        {
            Debug.Log("LB");
        }
        if (Input.GetKeyDown("joystick button 5"))
        {
            Debug.Log("RB");
        }
        if (Input.GetKeyDown("joystick button 6"))
        {
            Debug.Log("Back");
        }
        if (Input.GetKeyDown("joystick button 7"))
        {
            Debug.Log("Start");
        }
        if (Input.GetKeyDown("joystick button 8"))
        {
            Debug.Log("LeftStickClick");
        }
        if (Input.GetKeyDown("joystick button 9"))
        {
            Debug.Log("RightStickClick");
        }

        //RT
        if (Input.GetAxisRaw("XBOX_RT") != 0)
        {
            if (rtaxis == false)
            {
                Debug.Log("RT");
                rtaxis = true;
            }
        }
        if (Input.GetAxisRaw("XBOX_RT") == 0)
        {
            rtaxis = false;
        }

        //LT
        if (Input.GetAxisRaw("XBOX_LT") != 0)
        {
            if (ltaxis == false)
            {
                Debug.Log("LT");
        
                ltaxis = true;
            }
        }
        if (Input.GetAxisRaw("XBOX_LT") == 0)
        {
            ltaxis = false;
       
        }


        //DPad X & Y
        DpadHorizX = Input.GetAxis("DPadHorizontal");
        DpadHorizY = Input.GetAxis("DPadVertical");

        IsLeft = false;
        IsRight = false;
        IsUp = false;
        IsDown = false;

        if (_LastX != DpadHorizX)
        {
            if (DpadHorizX == -1)
            {
                IsLeft = true;
                Debug.Log("Left");
            }
            else if (DpadHorizX == 1)
            {
                IsRight = true;
                Debug.Log("Right");
            }
        }

        if (_LastY != DpadHorizY)
        {
            if (DpadHorizY == -1)
            {
                IsDown = true;
                Debug.Log("Down");
            }
            else if (DpadHorizY == 1)
            {
                IsUp = true;
                Debug.Log("Up");
            }
        }

        _LastX = DpadHorizX;
        _LastY = DpadHorizY;

     
    }
}