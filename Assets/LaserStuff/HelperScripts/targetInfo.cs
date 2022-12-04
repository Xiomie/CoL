using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class targetInfo
{
    //If a target is in range, this method will return true. You can provide a position and direction for the ray, as well as the range and the layer mask. Provides what was hit as HitInfo.
    public static bool isTargetInRange(Vector3 rayPosition, Vector3 rayDirection, out RaycastHit hitInfo, float range, LayerMask mask)
    {
        return (Physics.Raycast(rayPosition, rayDirection, out hitInfo, range, mask));
    }
}
