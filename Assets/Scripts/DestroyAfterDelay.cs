using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour {

    public float delay = 3f;

    IEnumerator Start() {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

}
