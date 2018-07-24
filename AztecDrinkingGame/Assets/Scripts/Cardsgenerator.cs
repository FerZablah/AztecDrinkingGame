using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardsgenerator : MonoBehaviour {
	[SerializeField]
	private GameObject card;
	// Use this for initialization
	void Start () {

		createCircle(20, 5.4f);
		createCircle(10, 3.6f);
		createCircle(8, 1.8f);
		createCircle(1, 0.001f);
	}

	// Update is called once per frame
	void Update () {

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
     Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center-pos);
     Instantiate(card, pos, transform.rotation * Quaternion.Euler(0, 0,(i + 1) * -angle));
 		}
	}
}
