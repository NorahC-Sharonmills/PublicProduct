using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
	public int levelLoad = 1;
	public Gamemaster gm;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<Gamemaster>();
	}

	private void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Player")){
			levelLoad = levelLoad + 1;
			SceneManager.LoadScene(levelLoad);
		}
	}
	private void OnTriggerStay2D(Collider2D col){
		
	}
	private void OnTriggerExit2D(Collider2D col){
		
	}
}
