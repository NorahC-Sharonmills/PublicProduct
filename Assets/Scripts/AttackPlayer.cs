using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour {
	
	GameObject gameObj;
	Vector3 cameraOffset;
	float x = 1.8f;

	// Use this for initialization
	void Start () {
		gameObj = GameObject.Find("Player");
		cameraOffset = new Vector3(x, 0 , 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = gameObj.transform.position + cameraOffset;
	}

	public string Aaaa() {
		//Get the mouse position on the screen and send a raycast into the game world from that position.
            Vector2 worldPoint = this.transform.position;
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            //If something was hit, the RaycastHit2D.collider will not be null.
            if (hit.collider != null)
            {
				return hit.collider.name;
            }
		return "Fail";
	}
}
