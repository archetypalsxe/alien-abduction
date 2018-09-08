using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : SceneController {

    /**
     * Check for any keys being pressed
     */
    public void Update() {
        if (
            (Input.anyKeyDown | Input.touchCount > 0) & ready
        ) {
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        }
    }

    // Returns the amount of time to wait before along keys to be pressed
    protected override int getTimeToWait() {
      return 5;
    }

    // Return the subtext that should be displayed on the screen
    protected override string getSubText() {
      return "Press Any Key to Begin!";
    }
}
