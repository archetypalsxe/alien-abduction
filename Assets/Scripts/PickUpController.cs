using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour {
    static int count = 0;

    public static float globalAbductSpeedOffset = 0f;
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
        target = new Vector3(0, Camera.main.transform.position.y + 100, 0);
        StartCoroutine(AnimateOut());
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
        count++;
        Debug.Log("COUNT " + count);
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
	
    IEnumerator AnimateOut() {
        Shake shake = GetComponent <Shake>();
        if(shake != null)
        {
            Destroy(shake);
        }
        while (transform.position.y < Camera.main.transform.position.y + 100)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                ((abductSpeed) * PickUpController.globalAbductSpeedOffset )* Time.deltaTime
            );
            yield return 0;
        }
        gameObject.AddComponent<DestroyAfterDelay>();
    }

}
