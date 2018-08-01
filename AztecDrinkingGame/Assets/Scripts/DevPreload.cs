using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevPreload : MonoBehaviour {

	void Awake() {
  	GameObject check = GameObject.Find("__App");
  	if (check==null){
			print("entro");
		 	UnityEngine.SceneManagement.SceneManager.LoadScene("PreLoad");
		}
  }
}
