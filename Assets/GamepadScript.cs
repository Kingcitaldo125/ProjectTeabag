using UnityEngine;
using System.Collections;

public class GamepadScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        if(Input.GetButtonDown("gamepad_a"))
        {
            Debug.Log("A");
        }
        if (Input.GetButtonDown("gamepad_b"))
        {
            Debug.Log("B");
        }
        if (Input.GetButtonDown("gamepad_x"))
        {
            Debug.Log("X");
        }
        if (Input.GetButtonDown("gamepad_y"))
        {
            Debug.Log("Y");
        }
        if (Input.GetButtonDown("gamepad_lbumper"))
        {
            Debug.Log("Left Bumper");
        }
        if (Input.GetButtonDown("gamepad_rbumper"))
        {
            Debug.Log("Right Bumper");
        }
        if (Input.GetButtonDown("gamepad_back"))
        {
            Debug.Log("Back");
        }
        if (Input.GetButtonDown("gamepad_start"))
        {
            Debug.Log("Start");
        }
        if (Input.GetButtonDown("gamepad_lstickClick"))
        {
            Debug.Log("Left Stick Click");
        }
        if (Input.GetButtonDown("gamepad_rstickClick"))
        {
            Debug.Log("Right Stick Click");
        }



        if (Input.GetAxis("leftjoy_x") != 0)
        {
            if (Input.GetAxis("leftjoy_x") > 0.7f)
                Debug.Log("Left Joystick X +");
            if (Input.GetAxis("leftjoy_x") < -0.7f)
                Debug.Log("Left Joystick X -");
        }
        if (Input.GetAxis("leftjoy_y") != 0)
        {
            if (Input.GetAxis("leftjoy_y") > 0.7f)
                Debug.Log("Left Joystick Y +");
            if (Input.GetAxis("leftjoy_y") < -0.7f)
                Debug.Log("Left Joystick Y -");
        }



        if (Input.GetAxis("rightjoy_x") != 0)
        {
            if (Input.GetAxis("rightjoy_x") > 0.7f)
                Debug.Log("Right Joystick X +");
            if (Input.GetAxis("rightjoy_x") < -0.7f)
                Debug.Log("Right Joystick X -");
        }
        if (Input.GetAxis("rightjoy_y") != 0)
        {
            if (Input.GetAxis("rightjoy_y") > 0.7f)
                Debug.Log("Right Joystick Y +");
            if (Input.GetAxis("rightjoy_y") < -0.7f)
                Debug.Log("Right Joystick Y -");
        }


        if (Input.GetAxis("gpad_ltrigger") != 0)
        {
            if (Input.GetAxis("gpad_ltrigger") != 0.0f)
                Debug.Log("Left Trigger");
        }
        if (Input.GetAxis("gpad_rtrigger") != 0)
        {
            if (Input.GetAxis("gpad_rtrigger") != 0.0f)
                Debug.Log("Right Trigger");
        }


        if (Input.GetAxis("dpad_y") != 0)
        {
            if (Input.GetAxis("dpad_y") > 0.7f)
                Debug.Log("DPad Y +");
            if (Input.GetAxis("dpad_y") < -0.7f)
                Debug.Log("DPad Y -");
        }
        if (Input.GetAxis("dpad_x") != 0)
        {
            if (Input.GetAxis("dpad_x") > 0.7f)
                Debug.Log("DPad X +");
            if (Input.GetAxis("dpad_x") < -0.7f)
                Debug.Log("DPad X -");
        }


    }
}
