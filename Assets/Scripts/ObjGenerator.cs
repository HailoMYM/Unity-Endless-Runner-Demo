using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjGenerator : MonoBehaviour {

	public ObjectPooler thePool;

	public void Spawn( Vector3 startPosition )
	{
		GameObject obj = thePool.GetPooledObject();
		obj.transform.position = startPosition;
		obj.SetActive(true);
	}

}
