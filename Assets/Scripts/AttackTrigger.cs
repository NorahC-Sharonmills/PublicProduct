using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {
	public int damage = 20;
	public Player player;
	// public TestEnemy testEnemy;
	private void OnTriggerEnter2D(Collider2D col){

		TestEnemy Enemy = col.GetComponent<TestEnemy>();
		// if(col.isTrigger != true && col.CompareTag("Enemy")){
		if(Enemy != null)
		{
			// col.SendMessageUpwards("Damageee", damage);
			// Enemy.Damageee(damage);
			// testEnemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<TestEnemy>();
			// testEnemy.Damage(damage);
			// player.trigger.enabled = false;
		}
	}
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//Get the mouse position on the screen and send a raycast into the game world from that position.
		// Debug.Log(this.transform.position);
            Vector2 worldPoint = this.transform.position;
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            //If something was hit, the RaycastHit2D.collider will not be null.
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
            }
	}
}
