using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour {
	
	public Transform generationPoint;

	public ObjectPooler theObjectPool;
	public float width;

	//private CoinGenerator theCoinGenerator;


	//private TreeGenerator theTreeGenerator;
	//public float probabilityTree;

	// Use this for initialization
	void Start () {
		//theCoinGenerator = FindObjectOfType<CoinGenerator>();
		//theTreeGenerator = FindObjectOfType<TreeGenerator>();
	}

	// Update is called once per frame
	void Update () {
		while (transform.position.x < generationPoint.transform.position.x)
		{
			
			transform.position = new Vector3(transform.position.x + width, transform.position.y, transform.position.z);

			//Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);

			GameObject newPlatform = theObjectPool.GetPooledObject();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive(true);

			/*if ( Random.Range(0f,1f) < probabilityCoins )
			{
				theCoinGenerator.SpawnCoins("AAAA");
			}*/

			/*if ( Random.Range(0f,1f) < probabilityTree )
			{
				theTreeGenerator.SpawnTree(newPlatform.transform.position);
			}*/

		}
	}
}
