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

	public void showAlert(string message){
		print("alert script");
		canvas.alpha = 1f;
		textMessage.text = message;
	}
}
