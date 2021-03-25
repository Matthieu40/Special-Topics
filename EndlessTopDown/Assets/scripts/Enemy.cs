using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    //variables
    public float expVal;
    private PlayerStats player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    public override void Die()
    {
        player.AddExperience(expVal);
        base.Die();
    }
}
