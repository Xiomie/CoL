
using UnityEngine;

public class gunMechanics : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;

    public Camera cam;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            //Target target = hit.transform.GetComponent<Target>();

            //if(target != null)
            {
            //   target.takeDamage(damage);
            }
        }
    }
}
