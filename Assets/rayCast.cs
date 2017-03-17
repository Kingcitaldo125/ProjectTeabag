using UnityEngine;
using System.Collections;

public class rayCast : MonoBehaviour {

	public int rayCastRange = 500;

    GameObject Crosshair;

    // Use this for initialization
    void Start ()
    {
        Crosshair = GameObject.Find("CrosshairObject");
    }

	void castRay(float deviation) {
		//assuming the main camera is attached to the player
		Transform t = Camera.main.transform;
		RaycastHit hit;

		ArrayList a = new ArrayList ();

        Vector3 v = t.forward;
        v.x += Random.Range(-deviation, deviation);
        v.y += Random.Range(-deviation, deviation);
        v.z += Random.Range(-deviation, deviation);

		if (Physics.Raycast (t.position, v, out hit)) {
			a.Add (hit);
			a.Add (t.forward);
			hit.transform.SendMessage("rayCastHit", a, SendMessageOptions.DontRequireReceiver);
            //hit.transform.SendMessage("onTopTarget", hit.point, SendMessageOptions.DontRequireReceiver);
            //Debug.Log("Hello");
		}
	}

    void castRayRomano()
    {
        Transform t = Camera.main.transform;
        RaycastHit hit;
        if (Physics.Raycast(t.position, t.forward, out hit))
        {
            if (hit.distance<20)
                hit.transform.SendMessage("rayRomanoCastHit", hit.point, SendMessageOptions.DontRequireReceiver);
        }
    }
}
