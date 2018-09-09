﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  public void repeatLevel() {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void nextLevel() {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  public void mainMenu() {
      SceneManager.LoadScene(0);
  }

  public void mainLevel() {
      SceneManager.LoadScene(1);
  }

  public void credits() {
      SceneManager.LoadScene("Credits");
  }

  public void quit() {
      Application.Quit();
  }
}
