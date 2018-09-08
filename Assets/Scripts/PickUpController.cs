using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour {

    public float abductSpeed = 3f;
    public float disappearDistance = 100;

    // @TODO This should be private
    public bool triggered = false;

    protected Vector3 target;
    protected bool animate = false;

    public bool isTriggered() {
        return triggered;
    }

    public void setTriggered() {
        triggered = true;
    }

    public void setNotTriggered() {
        triggered = false;
    }

    public void Animate() {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().mass = 0;
        target = new Vector3(0, disappearDistance, 0);
        animate = true;
    }

	// Use this for initialization
	void Start () {
        target = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if(animate) {
            transform.position = Vector3.MoveTowards(transform.position, target, abductSpeed * Time.deltaTime);
            if(transform.position == target) {
                gameObject.SetActive (false);
            }
        }
	}
}
