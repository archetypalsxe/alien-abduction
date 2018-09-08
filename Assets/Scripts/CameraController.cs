using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offsetValue;

    /**
     * Used for initialization
     */
	void Start ()
    {
        offsetValue = transform.position - player.transform.position;
	}
	
    /**
     * Called once per frame, but runs last after all other items are updated.
     * Ensures that the player has already moved
     */
	void LateUpdate ()
    {
        transform.position = player.transform.position + offsetValue;
	}
}
