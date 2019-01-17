using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveEnemy : MonoBehaviour {
	public enum statusMove
	{
		left,
		right,
	}

	private int stepTime;

	private statusMove currentStatus = statusMove.left;

	// Use this for initialization
	void Start () {
		stepTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentStatus == statusMove.left){
			this.transform.position += Vector3.left * Time.deltaTime;
			stepTime += 1;
			if(stepTime >= 180){
				currentStatus = statusMove.right;
				this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, 0);
				stepTime = 0;
			}
		}else{
			this.transform.position += Vector3.right * Time.deltaTime;
			stepTime += 1;
			if(stepTime >= 180){
				currentStatus = statusMove.left;
				this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, 0);
				stepTime = 0;
			}
		}
	}
}
