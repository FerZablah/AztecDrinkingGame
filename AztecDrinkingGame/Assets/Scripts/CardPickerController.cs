using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPickerController : MonoBehaviour {

    [SerializeField]
    private Text textMessage;
    private CanvasGroup canvas;
    // Use this for initialization
    void Start () {
        canvas = gameObject.GetComponent<CanvasGroup>();
        canvas.alpha = 1f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
