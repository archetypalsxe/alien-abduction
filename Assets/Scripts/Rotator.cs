using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    /**
     * Called once per frame. Want it to rotate every update
     */
	void Update () {
        transform.Rotate(new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}
