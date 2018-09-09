using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRing : MonoBehaviour {

    public Transform player;
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(.5f * player.localScale.x, 
            .5f * player.localScale.x,
            .5f * player.localScale.z );
    }
}
