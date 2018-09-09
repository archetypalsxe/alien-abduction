using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore : MonoBehaviour {

    public int highscore = 0;
    const string HIGHSCORE_KEY = "Highscore Key";

	void Awake () {
        LoadHighscore();
    }
	
    public void SaveHighscore(int score)
    {
        PlayerPrefs.SetInt(HIGHSCORE_KEY, score);
        PlayerPrefs.Save();
    }

    public void LoadHighscore()
    {
        highscore = PlayerPrefs.GetInt(HIGHSCORE_KEY, 0);
    }
}
