using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance=null;
	// Use this for initialization
	void Awake(){
		if(instance!=null){
			Destroy(gameObject);
			Debug.Log ("Duplicate MusicPlayer Destroyed");
		}
		else{
			instance=this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
		Debug.Log("Music player awake"+GetInstanceID());
	}
	void Start () {
		Debug.Log("Music player start"+GetInstanceID());
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
