﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour {

    Text text;

	// Use this for initialization
	void Start () {
        text = gameObject.GetComponent<Text>();
        text.text = HighScoreStorage.GetHighScore().ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
