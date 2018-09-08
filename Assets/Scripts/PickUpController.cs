using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour {

    public float abductSpeed = 3f;
    public float disappearDistance = 50;

    protected Vector3 target;
    protected bool animate = false;

    public void Animate() {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        target = new Vector3(0, disappearDistance, 0);
        Debug.Log(target);
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
