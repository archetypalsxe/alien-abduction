using UnityEngine;
using UnityEngine.UI;
using System.Collections;

abstract public class SceneController : MonoBehaviour {

	/**
	 * Text saying to press any key to begin
	 */
	public Text subText;

	/**
	 * Whether or not pressing a key will have any affect
	 */
	protected bool ready = false;

	// Abstract method to mandate that the time to wait is set
	abstract protected int getTimeToWait();

	// Returns the subtext that should be displayed after the delay
	abstract protected string getSubText();

	// Use this for initialization
	void Start () {
		subText.text = "";
		IEnumerator coroutine = this.waitSomeTime(this.getTimeToWait());
		StartCoroutine(coroutine);
	}

  protected IEnumerator waitSomeTime(int seconds) {
      yield return new WaitForSeconds(seconds);
			this.subText.text = this.getSubText();
      this.ready = true;
  }
}
