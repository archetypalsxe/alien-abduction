using UnityEngine;
using UnityEngine.SceneManagement;

public class ClosingScreen : SceneController {

    /**
     * Check for any keys being pressed
     */
    public void Update() {
			if (SystemInfo.deviceType == DeviceType.Handheld) {
				if (
            (Input.anyKeyDown | Input.touchCount > 0) & ready
        ) {
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        }
			} else {
				if (ready && Input.GetKeyDown("space")) {
					SceneManager.LoadScene("Level1", LoadSceneMode.Single);
				}
        if (ready && Input.GetKeyDown(KeyCode.Escape)) {
					Application.Quit();
				}
			}
    }

    // Returns the amount of time to wait before along keys to be pressed
    protected override int getTimeToWait() {
      return 5;
    }

		protected override string getSubText() {
			if (SystemInfo.deviceType == DeviceType.Handheld) {
				return "Tap to play again";
			} else {
				return "Press Escape to Quit or Space Bar to Play Again!";
			}
		}
}
