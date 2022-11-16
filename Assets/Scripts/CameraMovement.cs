using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform camTarget;
    public float plerp = .02f;
    public float rlerp = .01f;
    
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, camTarget.position, plerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rlerp);
    }
}
