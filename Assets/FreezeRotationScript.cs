using UnityEngine;
using System.Collections;

public class FreezeRotationScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if (rb)
        {
            rb.freezeRotation = true;
        }
        else
        {
            print("Attached GameObject Does not have a RigidBody to Freeze");
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
