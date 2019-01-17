using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour {
	public int Health;

	// Use this for initialization
	void Start () {
		Health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if(Health <= 0){
			Destroy(gameObject);
		}
	}

	public void Damageee(int damage){
		Health -= damage;
	}

}
