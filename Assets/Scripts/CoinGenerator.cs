using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

	public Transform generationPoint;

    public ObjectPooler theCoinPool;

	public float spaceBetweenLetters;
	public float spaceBetweenWords;
	public float spaceBetweenCoins;
	public float probabilityCoins;

	private Dictionary<char, List<int> > bitAlphabet = new Dictionary<char, List<int> >();
	public float delta;

	void Start () 
	{
		bitAlphabet.Add ('A',new List<int> () { 15,52,68,52,15 });
		bitAlphabet.Add ('B',new List<int> () { 127,73,73,73,54 });
		bitAlphabet.Add ('C',new List<int> () { 62,65,65,65,34 });
		bitAlphabet.Add ('D',new List<int> () { 127,65,65,65,62 });
		bitAlphabet.Add ('E',new List<int> () { 127,73,73,73,65 });
		bitAlphabet.Add ('F',new List<int> () { 127,72,72,72,64 });
		bitAlphabet.Add ('G',new List<int> () { 62,65,65,69,38 });
		bitAlphabet.Add ('H',new List<int> () { 127,8,8,8,127 });
		bitAlphabet.Add ('I',new List<int> () { 65,65,127,65,65 });
		bitAlphabet.Add ('J',new List<int> () { 6,1,1,1,126 });
		bitAlphabet.Add ('K',new List<int> () { 127,8,20,34,65 });
		bitAlphabet.Add ('L',new List<int> () { 127,1,1,1,1 });
		bitAlphabet.Add ('M',new List<int> () { 127,32,16,32,127 });
		bitAlphabet.Add ('N',new List<int> () { 127,32,28,2,127 });
		bitAlphabet.Add ('O',new List<int> () { 62,65,65,65,62 });
		bitAlphabet.Add ('P',new List<int> () { 127,72,72,72,48 });
		bitAlphabet.Add ('Q',new List<int> () { 62,65,69,66,61 });
		bitAlphabet.Add ('R',new List<int> () { 127,72,76,74,49 });
		bitAlphabet.Add ('S',new List<int> () { 50,73,73,73,38 });
		bitAlphabet.Add ('T',new List<int> () { 64,64,127,64,64 });
		bitAlphabet.Add ('U',new List<int> () { 126,1,1,1,126 });
		bitAlphabet.Add ('V',new List<int> () { 124,2,1,2,124 });
		bitAlphabet.Add ('W',new List<int> () { 127,2,12,2,127 });
		bitAlphabet.Add ('X',new List<int> () { 65,54,8,54,65 });
		bitAlphabet.Add ('Y',new List<int> () { 96,24,7,24,96 });
		bitAlphabet.Add ('Z',new List<int> () { 67,69,73,81,97 });
		bitAlphabet.Add ('1',new List<int> () { 17,33,127,1,1 });
		bitAlphabet.Add ('2',new List<int> () { 33,67,69,73,49 });
		bitAlphabet.Add ('3',new List<int> () { 34,65,73,73,54 });
		bitAlphabet.Add ('4',new List<int> () { 12,20,36,127,4 });
		bitAlphabet.Add ('5',new List<int> () { 121,73,73,73,70 });
		bitAlphabet.Add ('6',new List<int> () { 62,73,73,73,38 });
		bitAlphabet.Add ('7',new List<int> () { 64,64,71,88,96 });
		bitAlphabet.Add ('8',new List<int> () { 54,73,73,73,54 });
		bitAlphabet.Add ('9',new List<int> () { 50,73,73,73,62 });
		bitAlphabet.Add ('0',new List<int> () { 62,65,73,65,62 });
		bitAlphabet.Add ('+',new List<int> () { 8,8,62,8,8 });
		bitAlphabet.Add ('*',new List<int> () { 107,28,62,28,107 });
		bitAlphabet.Add ('=',new List<int> () { 0,20,20,20,0 });
		bitAlphabet.Add ('-',new List<int> () { 0,8,8,8,0 });
		bitAlphabet.Add (' ',new List<int> () { 0,0,0,0 });

	}

	void Update () {
		
		while (transform.position.x < generationPoint.transform.position.x) 
		{
			//Debug.Log (transform.position.x);
			//Debug.Log ("GP = " + generationPoint.position.x);
			transform.position = new Vector3 (transform.position.x + spaceBetweenCoins * delta, transform.position.y, transform.position.z);
			if ( Random.Range (0f, 1f) < probabilityCoins) 
			{
				Debug.Log (1);
				SpawnCoins ("ABCDEFGHIJKLMNOPQRSTUVWXYZ 0123456789+*-=");
			}

		}
	}

	public void SpawnCoins( string word )
    {


		for (int i = 0; i < word.Length; i++)
        {
			//Debug.Log (word[i].);
			foreach (int mask in bitAlphabet[word[i]]) 
			{
				for (int k = 0; k < 7; k++) 
				{
					if ((mask & (1 << k)) > 0) 
					{
						SpawnCoin (new Vector3 (transform.position.x, transform.position.y + k * delta, transform.position.z));
					}
				}
				transform.position = new Vector3 (transform.position.x + delta, transform.position.y, transform.position.z);
			}
			transform.position = new Vector3 (transform.position.x + spaceBetweenLetters*delta, transform.position.y, transform.position.z);
        }

    }

	public void SpawnCoin( Vector3 startPosition )
	{
		GameObject coin = theCoinPool.GetPooledObject();
		coin.transform.position = new Vector3(startPosition.x, startPosition.y + 1, startPosition.z);
		coin.SetActive(true);
	}

}
