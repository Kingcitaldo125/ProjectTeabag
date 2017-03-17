using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class triggerScript : MonoBehaviour
{
    GameObject mObj;
    public GameObject container;
    bool triggered = false;
    void Start()
    {
        mObj = gameObject;
        for(int i=0;i<container.transform.childCount;i++)
        {
            UnityEngine.Transform go= container.transform.GetChild(i);
            go.position -= new Vector3(0, go.transform.localScale.y / 2, 0);
            go.Rotate(new Vector3(0, 0, 90));
        }
    }
	void OnCollisionEnter(Collision col)
    {
        if (!triggered)
        {
            for (int i = 0; i < container.transform.childCount; i++)
            {
                UnityEngine.Transform go = container.transform.GetChild(i);

                go.SendMessage("eventTriggered", null, SendMessageOptions.DontRequireReceiver);
            }
            triggered = true;
        }
    }
}
