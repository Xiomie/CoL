using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource audioLaser;
    private void Start()
    {
        audioLaser = GetComponent<AudioSource>();
    }
    void Awake()
    {

    }

    Vector3 pos;
    public float offset = 3f;
    public Transform camTarget;
    public float plerp = .02f;
    public float rlerp = .01f;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            audioLaser.Play();
        }
        pos = Input.mousePosition;
        pos.z = offset;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
        transform.position = Vector3.Lerp(transform.position, camTarget.position, plerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rlerp);
    }
}