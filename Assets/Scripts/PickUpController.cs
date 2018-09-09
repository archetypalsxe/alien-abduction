﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour {

    public float abductSpeed = 3f;
    public float disappearDistance = 100;
    public float pointValue = 1f;

    private bool triggered = false;
    protected Vector3 target;

    public bool isTriggered() {
        return triggered;
    }

    public void setTriggered() {
        triggered = true;
    }

    public void setNotTriggered() {
        triggered = false;
    }

    public void Animate(float speedMultiplier) {
        GameObject.Find("CollectAudioManager").GetComponent<AudioManager>().PlayRandom();
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().mass = 0;
        target = new Vector3(0, disappearDistance, 0);
        StartCoroutine(AnimateOut(speedMultiplier));
    }

    public void StartShaking()
    {
        Shake shake = GetComponent<Shake>();
        if (shake == null)
        {
            gameObject.AddComponent<Shake>();
            Debug.Log("START SHAKING");
        }
    }

    // Use this for initialization
    void Start () {
        target = transform.position;
        gameObject.tag = "Pick Up";
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = true;
        //collider.size = new Vector3(0.01f, collider.size.y, );
        Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
        if(!rigidBody) {
            rigidBody = gameObject.AddComponent<Rigidbody>();
        }
        rigidBody.isKinematic = true;
	}
	
    IEnumerator AnimateOut(float speedMultiplier) {
        Shake shake = GetComponent <Shake>();
        if(shake != null)
        {
            Destroy(shake);
        }
        while (transform.position != target && transform.position.y < 50)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                (abductSpeed * GlobalPickupController.GetGlobalPickupModifier() * speedMultiplier) * Time.deltaTime
            );
            yield return 0;
        }
        gameObject.AddComponent<DestroyAfterDelay>();
    }

}
