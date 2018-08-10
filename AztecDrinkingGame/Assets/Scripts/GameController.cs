using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    enum State { Guessing, Picking, Displaying };

    // Use this for initialization
    private State gameState;

	void Start () {
        gameState = State.Guessing;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
