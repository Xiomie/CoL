using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthComponent : HealthComponent
{


    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();

        //Destruction particles
        //Play explosion sound
    }
}
