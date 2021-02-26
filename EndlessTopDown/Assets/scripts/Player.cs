using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variables
    public float movementSpeed; //player movement speed
    public GameObject Camera;

    public GameObject PlayerObj;

    public GameObject bulletSpawnPoint;
    public float waitTime;
    public GameObject bullet;

    private Transform bulletSpawned;

    public float points;

    public float health;
    public float maxHealth;

    //Methods

    void Start()
    {
        health = maxHealth;
    }
    void Update()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position); //plane that tracks camera position
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition); //player always faces direction of cursor
        float hitDist = 0.0f;

        if(playerPlane.Raycast(ray, out hitDist))
        {
            //Debug.Log("it worked");
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            PlayerObj.transform.rotation = Quaternion.Slerp(PlayerObj.transform.rotation, targetRotation, 7f * Time.deltaTime);
        }

        //player Movement
        if (Input.GetKey(KeyCode.W))
            //Debug.Log("it worked");
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);


        //shooting
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        //PlayerHealth
        if (health <= 0)
            Die();
    }

    void Shoot()
    {
        bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        bulletSpawned.rotation = bulletSpawnPoint.transform.rotation;

    }

    public void Die()
    {
        print("You have died");
    }

}
