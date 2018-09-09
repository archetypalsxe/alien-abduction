using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPickupController : MonoBehaviour {

    const float GLOBAL_PICKUP_MODIFIER = 3f;

    public static float GetGlobalPickupModifier() {
        return GLOBAL_PICKUP_MODIFIER;
    }
}
