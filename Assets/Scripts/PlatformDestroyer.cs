using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

    private GameObject platformDestroyerPoint;
	// Use this for initialization
	void Start () {
        platformDestroyerPoint = GameObject.Find("DestructionPoint");
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < platformDestroyerPoint.transform.position.x)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
	}
}
