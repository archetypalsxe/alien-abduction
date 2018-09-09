using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreStorage : MonoBehaviour {

    const string HIGH_SCORE = "high_score";

    public static void ResetHighScore() {
        PlayerPrefs.SetFloat(HIGH_SCORE, 0);
    }

    public static float GetHighScore() {
        float highScore = PlayerPrefs.GetFloat (HIGH_SCORE);
        if (highScore < 1) {
            return 0;
        }
        return highScore;
    }

    public static void SetHighScore(float highScore) {
        if(highScore > GetHighScore()) {
            PlayerPrefs.SetFloat (HIGH_SCORE, highScore);
        } else {
            Debug.LogWarning("High score ignored, existing high score is higher");
        }
    }
}
