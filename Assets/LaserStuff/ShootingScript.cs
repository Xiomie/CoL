using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Transform projectile;

    public float fireRate = 0.1f;

    public GameObject muzzlePosition;

    float cooldown = 0;
    void Update()
    {
        if (Input.GetButton("Fire1") && cooldown >= fireRate)
        {
            Instantiate(projectile, muzzlePosition.transform.position, muzzlePosition.transform.rotation);
            cooldown = 0;
        }

        cooldown += Time.deltaTime;
    }
}
