using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //variables
    public float health;

    public virtual void TakeDamage(float dmg)
    {
        health -= dmg;

        //Debug.Log(health);//system test

        if(health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //Debug.Log("Dead");//system test
        Destroy(gameObject);
    }

}
