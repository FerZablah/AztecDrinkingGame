using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertController : MonoBehaviour {
	[SerializeField]
	private Text textMessage;
	private CanvasGroup canvas;
	// Use this for initialization
	void Start () {
		canvas = gameObject.GetComponent<CanvasGroup>();
		canvas.alpha = 0f;
	}

	// Update is called once per frame
	void Update () {

	}

	public void showAlert(string suit, int rank){
		print("alert script");
		canvas.alpha = 1f;
		textMessage.text = structureMessage(suit, rank);
	}

	string structureMessage(string suit, int rank){
		string rankText = rank.ToString();
		//Check if we need to use "a" or "an" in string
		bool firstIsVowel = false;
		if(rank == 1 || rank == 8){
			firstIsVowel = true;
		}
		//Change ranks to their names (1=as, 11=Jack, 12=Queen, 13=King)
		switch(rank){
			case 1:
				rankText = "As";
				break;
			case 11:
				rankText = "Jack";
				break;
			case 12:
				rankText = "Queen";
				break;
			case 13:
				rankText = "King";
				break;
			default:
				rankText = rank.ToString();
				break;
		}
		string firstMessage = "You've got " + (firstIsVowel ? "an " : "a ") +  rankText +  " of " +  suit + ". ";
		string secondMessage = "Drink " + rank +((rank == 1) ? " second" : " seconds") + ".";

		return firstMessage + secondMessage;
	}
}
