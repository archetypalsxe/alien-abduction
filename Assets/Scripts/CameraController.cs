using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offsetValue;
    private Vector3 startingScale;

    /**
     * Used for initialization
     */
	void Start ()
    {
        offsetValue = transform.position - player.transform.position;
        startingScale = player.transform.localScale;
	}
	
    /**
     * Called once per frame, but runs last after all other items are updated.
     * Ensures that the player has already moved
     */
	void LateUpdate ()
    {
        Vector3 difference = player.transform.localScale - startingScale;
        transform.position = player.transform.position + offsetValue + new Vector3(0, difference.x / 4, -(difference.x / 2));
	}
}
