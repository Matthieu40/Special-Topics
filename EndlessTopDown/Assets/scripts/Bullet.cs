using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float maxDistance;

    private GameObject triggeringEnemy;
    public float damage;

    void Update()
    {
        //moves bullet forward and controls bullet velocity
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //makes the bullet disappear after a certain distance.
        maxDistance += 1 * Time.deltaTime;

        if (maxDistance >= 5)
            Destroy(this.gameObject);
    }

    //makes it so that enemies die when health hits 0
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            triggeringEnemy = other.gameObject;
            triggeringEnemy.GetComponent<Enemy>().health -= damage;
            Destroy(this.gameObject);
        }
    }
}
