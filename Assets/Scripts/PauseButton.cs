using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour {
	public GameObject PauseUI;
	public bool pauseBool = false;

	// Use this for initialization
	void Start () {
		PauseUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P)){
			pauseBool = !pauseBool;
		}
		if(pauseBool){
			PauseUI.SetActive(true);
			Time.timeScale = 0;
		}
		else{
			PauseUI.SetActive(false);
			Time.timeScale = 1;
		}
	}

	public void ResumeGame() {
		pauseBool = false;
	}
	public void RestartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void QuitGame() {
		Application.Quit();
	}
}
