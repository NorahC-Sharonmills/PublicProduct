using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemaster : MonoBehaviour {
	public int pointsss = 1;
	public Text pointText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		pointText.text = "Points: " + (pointsss.ToString());
	}
}
