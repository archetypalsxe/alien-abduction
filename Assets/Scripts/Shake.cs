using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {

    float shakeIntervalSeconds = .15f;
    float intensity = .1f;
    Vector3 originalPos;

    // Use this for initialization
    void Start () {
        originalPos = transform.position;
        StartCoroutine(ShakeAnimation());
    }

    IEnumerator ShakeAnimation()
    {
        while(true)
        {
            transform.position = new Vector3(originalPos.x + Random.insideUnitCircle.x * intensity,
            transform.position.y,
            originalPos.z + Random.insideUnitCircle.y * intensity);
            yield return new WaitForSeconds(shakeIntervalSeconds);
        }

    }
}
