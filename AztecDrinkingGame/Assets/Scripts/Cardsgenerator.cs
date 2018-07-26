using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardsgenerator : MonoBehaviour {

	List<string> suits = new List<string> { "Clubs", "Diamonds", "Hearts", "Spades" };
	public class Card {
    public int rank;
    public string suit;
	}

	[SerializeField]
	private GameObject card;
	List<Card> cardPool = new List<Card>();
	// Use this for initialization
	void Start () {
		createCardsPool();
		createCircle(20, 5.4f);
		createCircle(10, 3.6f);
		createCircle(8, 1.8f);
		createCircle(1, 0.001f);
	}

	// Update is called once per frame
	void Update () {

	}

	void createCardsPool() {
		for(int i=0;i<13;i++){
			for(int j=0;j<4;j++){
				Card myCard = new Card(){ rank = i+1, suit = suits[j] };
				print(myCard.rank + " of " + myCard.suit);
				cardPool.Add(myCard);
			}
		}
	}
	Vector3 RandomCircle(Vector3 center, float radius, int i, int angle) {
		 // create random angle between 0 to 360 degrees
		 	float ang = i * angle;
		  Vector3 pos;
			pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
			pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
			pos.z = center.z;
			return pos;
	}

	void createCircle(int nOfCards,float radius){
		Vector3 center = transform.position;
		int angle = 360 / nOfCards;
 		for (int i = 0; i < nOfCards; i++){
     Vector3 pos = RandomCircle(center, radius, i + 1, angle);
     // make the object face the center
     GameObject cardPrefab = Instantiate(card, pos, transform.rotation * Quaternion.Euler(0, 0,(i + 1) * -angle));
		 CardController cardScript = cardPrefab.GetComponent<CardController>();
		 int rnd = (int)Random.Range(0, cardPool.Count - 1);
		 cardScript.rank = cardPool[rnd].rank;
		 cardScript.suit = cardPool[rnd].suit;
		 cardPool.RemoveAt(rnd);
 		}
	}
}
