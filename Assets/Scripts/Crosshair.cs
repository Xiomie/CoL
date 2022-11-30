using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Cursor.visible = false;

    }

    Vector3 pos;
    public float offset = 3f;
    public Transform camTarget;
    public float plerp = .02f;
    public float rlerp = .01f;

    void Update()
    {
        pos = Input.mousePosition;
        pos.z = offset;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
        transform.position = Vector3.Lerp(transform.position, camTarget.position, plerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rlerp);
    }
}