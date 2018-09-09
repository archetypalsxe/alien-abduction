using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public int pointValue = 1;
    static int count = 0;

	// Use this for initialization
	void Start () {
        count++;
        Debug.Log("PICKED UP COUNT " + count);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
