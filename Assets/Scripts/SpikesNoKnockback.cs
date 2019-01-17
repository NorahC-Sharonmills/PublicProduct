using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesNoKnockback : MonoBehaviour {
	public Player player;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collider2D){
		if(collider2D.CompareTag("Player")){
			player.Damage(1);
		}
	}
}
