using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float distanceDivisor = 2;
    public float distanceMultiplier = 1;

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
	void Update ()
    {
        Vector3 difference = player.transform.localScale - startingScale;
        transform.position = player.transform.position + offsetValue + new Vector3(
            0, difference.x / (distanceMultiplier * distanceDivisor), -(difference.x / distanceMultiplier)
        );
	}
}
