using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour {

	public ObjectPooler theTreePool;

	public void SpawnTree( Vector3 startPosition )
	{
		GameObject tree = theTreePool.GetPooledObject();
		float y = (float)( startPosition.y + 0.5 + (theTreePool.pooledObject.transform.lossyScale.y / 2f) );
		tree.transform.position = new Vector3(startPosition.x, y , startPosition.z);
		tree.SetActive(true);
	}

}
