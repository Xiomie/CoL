using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float health = 100f;

    public virtual void TakeDamage(float damage)
    {
        
        health -= damage;
        Debug.Log($"Taking Damage, New Health At: {health}");
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        
    }
}
