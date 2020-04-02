using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {
	
	public Transform generationPoint;

	public float delta;

	public ObjGenerator theSawGenerator;
	public ObjGenerator theSwingGenerator;
	public float probabilitySaw;
	public float probabilitySwing;
	public Transform sawY, swingY;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		while (transform.position.x < generationPoint.transform.position.x)
		{
			
			transform.position = new Vector3(transform.position.x + delta, transform.position.y, transform.position.z);

			//Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);

			float obstacle = Random.Range (0f, 1f);

			if ( obstacle < probabilitySaw )
			{
				theSawGenerator.Spawn(new Vector3 ( transform.position.x, sawY.position.y, transform.position.z ));
			}

			else if ( obstacle < (probabilitySwing + probabilitySaw) )
			{
				theSwingGenerator.Spawn(new Vector3 ( transform.position.x, swingY.position.y, transform.position.z ));
			}
		}
	}
}
