using UnityEngine;
using System.Collections;

public class finishLineScript : MonoBehaviour {

	public GameObject emitterPrefab;
    public GameObject timer;

	void OnTriggerEnter(Collider other) {
		if(emitterPrefab)
		{
            timer.SendMessage("finished");
			GameObject emitter = Instantiate(emitterPrefab);
			Vector3 pos = other.transform.position;
			pos.y = 0.0f;
			emitter.transform.position = pos;
			Destroy(emitter, 10.0f);
		}
		Destroy(gameObject);
	}
}
