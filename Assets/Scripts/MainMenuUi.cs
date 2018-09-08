using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUi : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayGame()
    {
        Debug.Log("TODO go to game");
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("credits");
    }
}
