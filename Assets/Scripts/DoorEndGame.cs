using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEndGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	private void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Player")){
			Debug.Log("Win");
		}
	}
}
