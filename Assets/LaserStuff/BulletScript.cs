using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10f;
    public Transform collisionParticle;

    public float lifetime = 2f;
    float lifetimePassed = 0;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        if (lifetimePassed >= lifetime)
        {
            Destroy(this.gameObject);
        }
        else
        {
            lifetimePassed += Time.deltaTime;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {

        //if(collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponet))
        {
        //    enemyComponet.takeDamage(1);
        }
       // Destroy(gameObject);
    }
}
