using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour {

	public int rank;
	public string suit;
	[SerializeField]
	// The target marker.
	private Transform target;
	[SerializeField]
	// Speed in units per sec.
	private float speed;
	private bool shouldShowCard = false;
	[SerializeField]
	public bool isTestCard = false;
	[SerializeField]
	private SpriteRenderer spriteRenderer;
	[SerializeField]
	private SpriteRenderer middleRankSprite;
	[SerializeField]
	private SpriteRenderer upRankSprite;
	[SerializeField]
	private SpriteRenderer bottomRankSprite;
	[SerializeField]
	private SpriteRenderer upSuitSprite;
	[SerializeField]
	private SpriteRenderer bottomSuitSprite;

	// Use this for initialization
	void Start () {
		if(!isTestCard){
			target =  GameObject.Find("TargetPosition").transform;
			Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/CardsElements");
			if(rank==1){
				print("As string: " + ("A"+suit[0]));
				middleRankSprite.sprite = getSprite("A"+suit[0], sprites);
			}
			else{
				middleRankSprite.sprite = getSprite(rank.ToString(), sprites);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if(shouldShowCard){
			showCard();
			if(Mathf.Abs(360 - transform.eulerAngles.x) > 85 /*||transform.eulerAngles.x < -95)*/){
				//Debug.Break();
			}
		}
	}

	void showCard(){
			// The step size is equal to speed times frame time.
	    float step = speed * Time.deltaTime;
	    // Move our position a step closer to the target.
	    transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
	void OnMouseDown(){
		shouldShowCard = true;
		float angle = transform.eulerAngles.z - target.eulerAngles.z;
		StartCoroutine(RotateMe((Vector3.back * angle)+(Vector3.up * 180), 1));
	}

	IEnumerator RotateMe(Vector3 byAngles, float inTime) {
           var fromAngle = transform.rotation;
           var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
           for(var t = 0f; t < 1; t += Time.deltaTime/inTime) {
                transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
                yield return null;
           }
  }

	Sprite getSprite(string name, Sprite[] sprites){
		Sprite spriteToReturn = null;
		for(int i=0;i<sprites.Length;i++){
			if(sprites[i].name == name){
				spriteToReturn = sprites[i];
			}
		}
		if(spriteToReturn){
			return spriteToReturn;
		}
		else {
			print("No se encontro sprite " + name);
			return null;
		}
	}

}
