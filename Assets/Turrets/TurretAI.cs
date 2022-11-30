using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    Transform Player;
    float dist;
    public float howClose;
    public Transform head;
    public Transform barrel;
    public GameObject projectile;
    public float fireRate;
    float nextFire;
    public float bulletSpeed = 1500;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(Player.position, transform.position);
        if(dist <= howClose)
        {
            head.LookAt(Player);
            if(Time.time >= nextFire)
            {
                nextFire = Time.time + 1f/fireRate;
                shoot();
            }
            
        }
    }

    void shoot()
    {
        GameObject clone = Instantiate(projectile, barrel.position, head.rotation);
        clone.GetComponent<Rigidbody>().AddForce(head.forward * bulletSpeed);
        Destroy(clone, 10);
    }
}