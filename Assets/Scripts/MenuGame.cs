using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour {
	public int SceneNext = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void StartGamme(){
		SceneManager.LoadScene(SceneNext);
	}
}
