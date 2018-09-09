using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float distanceDivisor = 2;
    public float distanceMultiplier = 1;

    public float heightOffset;
    public Vector3 offsetValue;
    private Vector3 startingScale;

    /**
     * Used for initialization
     */
    void Start()
    {
        offsetValue = transform.position - player.transform.position;
        startingScale = player.transform.localScale;
        StartCoroutine(SeeThroughObjectsDetectionRoutine());
    }

    /**
     * Called once per frame, but runs last after all other items are updated.
     * Ensures that the player has already moved
     */
    void Update()
    {
        //Vector3 difference = player.transform.localScale - startingScale;
        //transform.position = player.transform.position + offsetValue + new Vector3(
        //    0, difference.x / (distanceMultiplier * distanceDivisor), -(difference.x / distanceMultiplier)
        //);
        transform.position = player.transform.position + Vector3.forward * -(10 + heightOffset) + Vector3.up * (10 + heightOffset);
        transform.forward = (player.transform.position - transform.position).normalized;
    }

    IEnumerator SeeThroughObjectsDetectionRoutine()
    {
        const float tick = .5f;
        Vector3 target;
        while (true)
        {
            target = player.transform.position;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (target - transform.position).normalized, out hit) && 
                hit.rigidbody != null &&
                hit.rigidbody.tag.Equals("Pick Up"))
            {
                BlockCameraFade fader = hit.rigidbody.gameObject.GetComponent<BlockCameraFade>();
                if(fader == null)
                {
                   fader = hit.rigidbody.gameObject.AddComponent<BlockCameraFade>();
                }
                fader.hitByCamera();
            }
            yield return new WaitForSeconds(tick);
        }
    }
}
