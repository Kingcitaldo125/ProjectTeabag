using UnityEngine;
using System.Collections;

public class aimDownSightsScript : MonoBehaviour
{
    private bool isADS,adsTrigger;
    public Transform trans;

    private float curField = 60.0f;
    private float dampVelocity2 = 0.4f;

    /*private Vector3 transPos;
    private Vector3 transRot;*/

    public float curXPos = 1.32f;
    public float curYPos = -0.44f;
    public float curZPos = 2.85f;

    public float curXRot = 0.0f;
    public float curYRot = 5.5f;
    public float curZRot = 0.0f;

    public float newXPos = 0.65f;
    public float newYPos = -0.45f;
    public float newZPos = 2.76f;

    public float newXRot = 0.0f;
    public float newYRot = 1.0f;
    public float newZRot = 0.0f;

    //Holds references to all the cameras initially attached to the current gameObject
    private Camera[] playerCameraRefs = null;
    //Holds ref to the aimScript attached to this current gameObject
    private cameraAimScript aimScriptRef = null;

	private Vector3 moveTo = Vector3.zero; //this is the desired position of the gun
	private float travelDistance = 1.0f;
	private float newFov = 0.0f;


    // Use this for initialization
    void Start()
    {
        isADS = false;
        adsTrigger = false;

        //Initialize holding references
        playerCameraRefs = gameObject.GetComponents<Camera>();
        aimScriptRef = gameObject.GetComponent<cameraAimScript>();
    }

    void adsOld()
    {
        isADS = false;
        Vector3 newpos = trans.localPosition;
        Vector3 newRot = trans.localEulerAngles;

        newpos.x = curXPos;
        newpos.y = curYPos;
        newpos.z = curZPos;

       	//trans.localPosition = newpos;
		moveTo = newpos;
		travelDistance = Vector3.Distance (trans.localPosition, newpos);
        trans.localEulerAngles = new Vector3(curXRot, curYRot, curZRot);

        ADSChange(60.0f, false);

        //Debug.Log("Is Ads: " + isADS);
    }

    /// Adjusts user controls and FOV to given value (Not-smoothly)
    public void ADSChange(float fov, bool enteringADS = true)
    {
		newFov = fov;
        //Change the mouse aiming sensitivity
        //Check for null aimScript ref
        if (!aimScriptRef)
        {
            throw new UnityException("ADS script lost reference to the camera aim script");
        }
        aimScriptRef.toggleADS(enteringADS);
    }

    void adsNew()
    {
        isADS = true;
        Vector3 newpos = trans.localPosition;
        Vector3 newRot = trans.localEulerAngles;

        newpos.x = newXPos;
        newpos.y = newYPos;
        newpos.z = newZPos;

        //trans.localPosition = newpos;
		moveTo = newpos;
		travelDistance = Vector3.Distance (trans.localPosition, newpos);
        trans.localEulerAngles = new Vector3(newXRot, newYRot, newZRot);

        ADSChange(20.0f);

        //Debug.Log("Is Ads: " + isADS);
    }

    // Update is called once per frame
    void Update()
    {

		//if we have a position we want the gun to be at
		if (moveTo != Vector3.zero) {
			trans.localPosition = Vector3.MoveTowards (trans.localPosition, moveTo, Time.deltaTime * 12f);
			updateCamFovs ( 1 - (Vector3.Distance(trans.localPosition, moveTo) / travelDistance));

			if (trans.localPosition == moveTo) {
				moveTo = Vector3.zero;
				updateCamFovs (1);
			}
		}

        /**/if (Input.GetButtonDown("gamepad_b") && !isADS)
        {
            adsTrigger = true;
            adsNew();
        }
        else if (Input.GetButtonDown("gamepad_b") && isADS)
        {
            adsTrigger = false;
            adsOld();
        }/**/
        if (Input.GetMouseButtonDown(1) && !isADS)
            adsNew();
        else if (Input.GetMouseButtonDown(1) && isADS)
            adsOld();
    }

	void updateCamFovs(float percentage) {

		//gradual change
		foreach (Camera cam in playerCameraRefs) {
			//Check for null cam refs
			if (!cam) {
				throw new UnityException ("ADS script lost reference to a camera");
			}
				
			if (newFov > 0f) {
				if (isADS) {
					cam.fieldOfView = 60 - ((newFov + 20) * percentage);
				} else {
					cam.fieldOfView = 20 + (newFov - 20) * percentage;
				}

				if (cam.fieldOfView == newFov) {
					newFov = 0.0f;
				}
			}
		}
	}
}
