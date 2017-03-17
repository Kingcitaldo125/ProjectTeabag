using UnityEngine;
using System.Collections;

public class cameraAimScript : MonoBehaviour
{

    /// The hipfire sensitivity of the mouse x axis movement
    public float sensitivityX = 25000.0f;
    //The hipfire sensitivity of the mouse y axis movement
    public float sensitivityY = 25000.0f;

    //The sensitivity of the mouse x axis movement in ADS mode
    public float sensitivityXADS = 7000.0f;
    //The sensitivity of the mouse y axis movement in ADS mode
    public float sensitivityYADS = 7000.0f;

    //The active mouse x axis sensitivity
    private float activeSensiX = 0.0f;
    //The active mouse y axis sensitivity
    private float activeSensiY = 0.0f;

    public float GamepadSensitivityX = 0.5f;
    public float GamepadSensitivityY;// = GamepadSensitivityX;

    //The minimun angle that the player can look down towards the ground at
    public float minimumY = -60f;
    //The maximum angle that the player can look down towards the ground at
    public float maximumY = 60f;

    //The current rotation caused by user input
    public float rotationY = 0;
	private float rotationX = 0;
	
	private float recoilY = 0;
	public float decRecoilSpd = 1f;

    //State wether or not the ADS mode is active
    private bool inADSMode = false;

    private float oldRotationSpeed,newRotationSpeed;

	void Start ()
    {
        oldRotationSpeed = 3.5f;
        newRotationSpeed = 0.5f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        GamepadSensitivityY = GamepadSensitivityX;

        //Initalizing sensitivity
        toggleADS(false);
    }

    /// Toggles ADS mode for mouse input controls
    public void toggleADS()
    {
        toggleADS(!inADSMode);
    }
    /// Changes ADS mode for mouse input controls
    public void toggleADS(bool setADS)
    {
        switch (setADS)
        {
            case false:
                inADSMode = false;
                activeSensiX = sensitivityX;
                activeSensiY = sensitivityY;
                break;
            case true:
                inADSMode = true;
                activeSensiX = sensitivityXADS;
                activeSensiY = sensitivityYADS;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //float rotationX = 0.0f;
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * activeSensiX;
		if(recoilY > 0)
		{
		    recoilY -= decRecoilSpd;
            if(recoilY < 0)
            {
                float tmp = -recoilY;
                recoilY = 0;
                rotationY -= tmp;
            }else
		        rotationY -= decRecoilSpd;
		}
		rotationY += Input.GetAxis("Mouse Y") * activeSensiY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        /**/
        if (Input.GetAxis("rightjoy_x") != 0)
        {
            if (Input.GetAxis("rightjoy_x") > 0.01f || Input.GetAxis("rightjoy_x") < -0.01f)
            {
                Debug.Log(Input.GetAxis("rightjoy_x"));
                if (inADSMode)
                    GamepadSensitivityX = newRotationSpeed;
                else
                    GamepadSensitivityX = oldRotationSpeed;

                rotationX = transform.localEulerAngles.y + Input.GetAxis("rightjoy_x") * GamepadSensitivityX;
                //rotationX = transform.localEulerAngles.y + 0.001f * GamepadSensitivityX;
            }
        }
        if (Input.GetAxis("rightjoy_y") != 0)
        {
            if (Input.GetAxis("rightjoy_y") > 0.01f || Input.GetAxis("rightjoy_y") < -0.01f)
            {
                Debug.Log(Input.GetAxis("rightjoy_y"));
                if (inADSMode)
                    GamepadSensitivityY = newRotationSpeed;
                else
                    GamepadSensitivityY = oldRotationSpeed;
                rotationY -= Input.GetAxis("rightjoy_y") * GamepadSensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            }
        }
        /**/


        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

    }
	
	void recoil(float recoilPow)
    {
        recoilY = recoilPow;
        rotationY += recoilPow;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
    }
}
