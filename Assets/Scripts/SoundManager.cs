using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioClip Coins;
	public AudioClip GameOver;
	public AudioClip Dead;
	public AudioSource audioSource;

	// Use this for initialization
	void Start () {
		Coins = Resources.Load<AudioClip>("Mario-coin-sound");
		GameOver = Resources.Load<AudioClip>("smb_gameover");
		Dead = Resources.Load<AudioClip>("smb_mariodie");
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	public void Playsound(string clip) {
		switch(clip){
			case "coins" :
				audioSource.clip = Coins;
				audioSource.PlayOneShot(Coins, 0.5f);
				break;
			case "over" :
				audioSource.clip = GameOver;
				audioSource.PlayOneShot(GameOver, 0.5f);
				break;
			case "dead" :
				audioSource.clip = Dead;
				audioSource.PlayOneShot(Dead, 0.5f);
				break;
		}
	}
}
