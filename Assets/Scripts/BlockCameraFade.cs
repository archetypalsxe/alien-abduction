using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCameraFade : MonoBehaviour {

    DateTime lastHitTime;
    const float revertCheckInterval = .5f;

    IEnumerator RevertToOriginalAlpha()
    {
        while(true)
        {
            if((DateTime.UtcNow - lastHitTime).TotalSeconds > 1f)
            {
                resetAlpha();
            }
            yield return new WaitForSeconds(revertCheckInterval);
        }   
    }

    public void hitByCamera()
    {
        lastHitTime = DateTime.UtcNow;
        foreach (Material mat in GetComponent<Renderer>().materials)
        {
            Color color = mat.color;
            color.a = 0.5f;
            mat.SetColor("_Color", color);
        }
        StartCoroutine("RevertToOriginalAlpha");
    }

    public void resetAlpha()
    {
        foreach (Material mat in GetComponent<Renderer>().materials)
        {
            Color color = mat.color;
            color.a = 1f;
            mat.SetColor("_Color", color);
        }
        Destroy(this);
    }
}
