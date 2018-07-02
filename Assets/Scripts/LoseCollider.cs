using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	private LevelManager levelmanager;
	void start(){
		
	}
	// Use this for initialization
	void OnTriggerEnter2D (Collider2D trigger) {
		print("Trigger");
		levelmanager=GameObject.FindObjectOfType<LevelManager>();
		levelmanager.LoadLevel("Lose");
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D collision) {
		print ("Collision");
		levelmanager=GameObject.FindObjectOfType<LevelManager>();
		levelmanager.LoadLevel("Lose");
	}
}
