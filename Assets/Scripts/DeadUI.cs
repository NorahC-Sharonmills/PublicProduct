using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadUI : MonoBehaviour {
	public GameObject DeadUIGame;
	public bool DeadUIBool = false;

	// Use this for initialization
	void Start () {
		DeadUIGame.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
