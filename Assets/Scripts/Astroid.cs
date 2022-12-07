using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Astroid : MonoBehaviour
{
    // Start is called before the first frame update

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            
            gameObject.SetActive(false);
        }


        if (collision.gameObject.tag == "Projectile")
        {
            gameObject.SetActive(false);
        }

    }
}
