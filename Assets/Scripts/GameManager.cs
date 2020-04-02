using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

	public PlayerController thePlayer;
	public GameObject theDeadPlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;

    public DeathMenu theDeathScreen;

	// Use this for initialization
	void Start () {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        theScoreManager = FindObjectOfType<ScoreManager>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RestartGame()
    {
        //StartCoroutine("RestartGameCo");

        theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive(false);
		theDeadPlayer.transform.position = thePlayer.gameObject.transform.position;
		theDeadPlayer.SetActive(true);

        theDeathScreen.gameObject.SetActive(true);

    }

    public void ResetGame()
    {
        theDeathScreen.gameObject.SetActive(false);

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
		theDeadPlayer.SetActive(false);
        thePlayer.gameObject.SetActive(true);
    }

    /*public IEnumerator RestartGameCo()
    {
        
        yield return new WaitForSeconds(0.5f);

        platformList = FindObjectsOfType<PlatformDestroyer>();

        for(int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
        thePlayer.gameObject.SetActive(true);

    }*/

}
