using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour {
	GameObject gameObj;
	Vector3 cameraOffset;
	// Use this for initialization
	void Start () {
		gameObj = GameObject.Find("Player");
		cameraOffset = new Vector3(0, 1 , -5);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = gameObj.transform.position + cameraOffset;
	}
}
