using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePopUpTextMesh : MonoBehaviour {

    public float speed = 35.0f;
    public float destroyTime = .5f;

    void Start()
    {
        StartCoroutine(TimedDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(0, 1000), speed * Time.deltaTime);
    }

    IEnumerator TimedDestroy()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
    }

}
