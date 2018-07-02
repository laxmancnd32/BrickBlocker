using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	private LevelManager levelmanager;
	public AudioClip crack;
	private int timesHit;
	public Sprite[] hitSprites;
	public static int breakableCount=0;
	private bool isbreakable;
	public GameObject smoke;
	// Use this for initialization
	void Start () {
		timesHit=0;
		//Keeps track of breakable brick
		isbreakable=(this.tag=="Breakable");
		if(isbreakable){
			breakableCount++;
			print (breakableCount);
			}
		levelmanager=GameObject.FindObjectOfType<LevelManager>();
	}
	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint(crack,this.transform.position);
		if(isbreakable)
			HandleHits();
	}
	
	void HandleHits(){
		print ("Collision");
		timesHit++;
		int maxHits = hitSprites.Length+1;
		if(timesHit>=maxHits){
			breakableCount--;
			levelmanager.BrickDestroyed();
			puffSmoke();
			Destroy(gameObject);
			print (breakableCount);
		}
		else
			LoadSprites();
	}
	void puffSmoke(){
		GameObject smokeObj=(GameObject)Instantiate(smoke,gameObject.transform.position,Quaternion.identity);
		smokeObj.particleSystem.startColor=gameObject.GetComponent<SpriteRenderer>().color;
	}
	void LoadSprites(){
		int spriteIndex=timesHit-1;
		if(hitSprites[spriteIndex])
			this.GetComponent<SpriteRenderer>().sprite=hitSprites[spriteIndex];
	}
	
	// Update is called once per frame
	void Update () {
			
	}
	void SimulateWin(){
		levelmanager.LoadNextLevel();
	}
}
