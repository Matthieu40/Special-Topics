using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //Variables
    public float health;
    public float pointsToGive;

    public GameObject player;

    //Methods
    public void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    //kills enemy when health depletes
    public void Update()
    {
        if(health <= 0)
        {
            Die();
        }
    }

    //death function
    public void Die()
    {
        Destroy(this.gameObject);

        player.GetComponent<Player>().points += pointsToGive;
    }
}
