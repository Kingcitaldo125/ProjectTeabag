using UnityEngine;
using System.Collections;

public class wallHit : MonoBehaviour {

	public GameObject emitterPrefab;

	void rayCastHit(ArrayList list)
	{
		if (emitterPrefab)
		{
			GameObject emitter = Instantiate(emitterPrefab);
			emitter.transform.position = ((RaycastHit)list[0]).point;

			Vector3 forward = (Vector3)list [1];
			Quaternion rotation = Quaternion.LookRotation (-forward);

			emitter.transform.rotation = rotation;

			Destroy(emitter, 3.0f);
		}
	}
}
