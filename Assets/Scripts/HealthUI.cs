﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {
	public Sprite[] heartSprite;
	public Player player;
	public Image Heart;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.ourHealth > 5)
            player.ourHealth = 5;
 
 
        if (player.ourHealth < 0)
            player.ourHealth = 0;

		Heart.sprite = heartSprite[player.ourHealth];
	}
}
