using UnityEngine;
using System.Collections;

public class moveScript : MonoBehaviour
{
    //Uses attached to gameobject if left blank
    GameObject mTarget;
    //public float mSpeed = 0.05f;

    private float originalSpeed;
    private float distToGround;

    //The speed scale to apply to all direcitons
    public float speedScale = 1.0f;

    //The foward facing speed 
    public float forwardSpeed = 0.125f;
    //The bakcward facing speed
    public float backwardSpeed = 0.07f;
    //The speed for was strafing left and right
    public float strafeSpeed = 0.08f;
    public float jumpForce = 10.0f;

    //private bool isADS = false;

    void doGamepadShit()
    {
        if (Input.GetButtonDown("gamepad_a"))
            Debug.Log("A");
        if (Input.GetButtonDown("gamepad_b"))
            Debug.Log("B");
        if (Input.GetButtonDown("gamepad_x"))
            Debug.Log("X");
        if (Input.GetButtonDown("gamepad_y"))
            Debug.Log("Y");
        if (Input.GetButtonDown("gamepad_lbumper"))
            Debug.Log("Left Bumper");
        if (Input.GetButtonDown("gamepad_rbumper"))
            Debug.Log("Right Bumper");
        if (Input.GetButtonDown("gamepad_back"))
            Debug.Log("Back");
        if (Input.GetButtonDown("gamepad_start"))
            Debug.Log("Start");
        if (Input.GetButtonDown("gamepad_lstickClick"))
            Debug.Log("Left Stick Click");
        if (Input.GetButtonDown("gamepad_rstickClick"))
            Debug.Log("Right Stick Click");

        if (Input.GetAxis("leftjoy_x") != 0)
        {
            if (Input.GetAxis("leftjoy_x") > 0.7f)
                Debug.Log("Left Joystick X +");
            if (Input.GetAxis("leftjoy_x") < -0)
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

    void FixedUpdate()
    {
        //doGamepadShit();

        mTarget = gameObject;

        //get the object's forward vector that will be used for forward/backwards movement
        Vector3 facing = mTarget.transform.forward;
        if (facing.x >= 180)
            facing.x -= 360;
        if (facing.z >= 180)
            facing.z -= 360;
        if (facing.x == 0 && facing.z == 0)
            facing.z = 1;

        facing.y = 0;
        facing.Normalize();

        //get the vector that will be used for left/right movement
        Vector3 facingLR = Vector3.Cross(facing, new Vector3(0, 1, 0));
        facingLR.Normalize();

        //Direction of movement (x+ right, x- left, y+ forward, y-backwards) needs to be normalized before position change
        Vector2 movementDirection = new Vector2(0, 0);

        //Get Gamepad movement... oddly all the directions on gamepad axes are inverted
        Vector3 posChange = new Vector3(0, 0, 0);

        //Could through these in the movementDirection var's initializer, idk
        movementDirection.x = -Input.GetAxis("leftjoy_x");
        movementDirection.y = -Input.GetAxis("leftjoy_y");

        /*if (Input.GetAxis("leftjoy_x") != 0)
        {
            if (Input.GetAxis("leftjoy_x") > 0.7f)
                posChange -= facingLR;
            if (Input.GetAxis("leftjoy_x") < -0)
                posChange += facingLR;
        }

        if (Input.GetAxis("leftjoy_y") != 0)
        {
            if (Input.GetAxis("leftjoy_y") > 0.7f)
                posChange -= facing;
            if (Input.GetAxis("leftjoy_y") < -0.7f)
                posChange += facing;
        }*/



        if (Input.GetKey("w"))
        {
            movementDirection.y += 1;
        }
        //posChange += facing;
        if (Input.GetKey("s"))
        {
            movementDirection.y -= 1;
        }
        //posChange -= facing;

        if (Input.GetKey("a"))
        {
            movementDirection.x += 1;
        }
        //posChange += facingLR;
        if (Input.GetKey("d"))
        {
            movementDirection.x -= 1;

        }
        //posChange -= facingLR;Input.GetAxis("gpad_ltrigger") != 0 Input.GetButtonDown("gamepad_y")
        if (Input.GetKey(KeyCode.Space) && IsGrounded() || Input.GetAxis("gpad_ltrigger") != 0 && IsGrounded())
        {
            mTarget.GetComponent<Rigidbody>().AddForce(Vector3.up * 100.0f);
        }

        movementDirection.Normalize();

        if (movementDirection.y > 0)
        {
            posChange += facing * forwardSpeed * movementDirection.y;
        }
        else
        {
            posChange += facing * backwardSpeed * movementDirection.y;
        }

        posChange += facingLR * strafeSpeed * movementDirection.x;

        /*if (movementDirection.x > 0)
        {
            posChange += facingLR * strafeSpeed * movementDirection.x;
        }
        else
        {
            posChange += facingLR * strafeSpeed * movementDirection.x;        
        }*/
        //posChange += facing * 10.0f * movementDirection.x;

        /*if (Input.GetMouseButtonDown(1) && isADS == false)
            isADS = true;
        else if(Input.GetMouseButtonDown(1) && isADS == true)
            isADS = false;*/

        /*if (isADS)
            mSpeed = 0.01f;
        else
            mSpeed = originalSpeed;*/
        mTarget.transform.position += speedScale * posChange;
    }

    void Start()
    {
        //originalSpeed = mSpeed;
        if (mTarget == null)
        {
            mTarget = gameObject;
        }
        distToGround = mTarget.GetComponent<Collider>().bounds.extents.y;
    }

    bool IsGrounded()
    {

        return Physics.Raycast(mTarget.transform.position, -Vector3.up, distToGround + 0.1f);

    }
}
