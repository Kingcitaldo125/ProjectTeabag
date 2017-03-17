using UnityEngine;
using System.Collections;

public class HitScript : MonoBehaviour
{
    GameObject mTarget;
    public GameObject emitterPrefab;

    void rayCastHit(Vector3 hitPosition)
    {
        mTarget = gameObject;
        if(emitterPrefab)
        {
            GameObject emitter = Instantiate(emitterPrefab);
            emitter.transform.position = hitPosition;
            Destroy(emitter, 3.0f);
        }
        mTarget.SetActive(false);
    }
}
