using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum GunType { single, burst, auto};//gun options (each one has different fire mode)//also creates dropdown on script settings

    public LayerMask collisionMask;
    public float gunID;
    public GunType gunType;
    public float rpm;
    public float damage = 1;

    
    public Transform spawn;//bullet spawn point
    public Transform shellEjection; //bullet shell spawner
    public Rigidbody shell;//bulletshell
    private LineRenderer tracer;//bullet trajectory
    private float secondsBetweenShots;
    private float nextPossibleShootTime;

    void Start()
    {
        secondsBetweenShots = 60 / rpm;
        if (GetComponent<LineRenderer>())//checks for line renderer effect
        {
            tracer = GetComponent<LineRenderer>();
        }
    }

    //Shooting now uses raycasting (before it was spawning bullets and the rate of fire was slow (also raycast animations are too cool)
    public void Shoot()
    {
        if (CanShoot())
        {
            Ray ray = new Ray(spawn.position, spawn.forward);
            RaycastHit hit;

            //ray travel dist
            float shotDistance = 20;

            if (Physics.Raycast(ray, out hit, shotDistance, collisionMask))
            {
                shotDistance = hit.distance;

                if (hit.collider.GetComponent<Entity>())//checks if bullet rays are hitting a valid target
                {
                    hit.collider.GetComponent<Entity>().TakeDamage(damage);//causes the bullets to do damage
                }
            }

            nextPossibleShootTime = Time.time + secondsBetweenShots;

           if (tracer)
            {
                StartCoroutine("RenderTracer", ray.direction * shotDistance);
            }

            Rigidbody newShell = Instantiate(shell, shellEjection.position,Quaternion.identity) as Rigidbody;//creates instance of shell and spawns it at the right point
            newShell.AddForce(shellEjection.forward * Random.Range(150f,200f) + spawn.forward * Random.Range(-10f,10f));
        }
    }

    //automatic fire mode
    public void ShootContinuous()
    {
        if(gunType == GunType.auto)
        {
            Shoot();
        }
    }

    private bool CanShoot()
    {
        bool canShoot = true;

        if (Time.time < nextPossibleShootTime)
        {
            canShoot = false;
        }

        return canShoot;
    }

    IEnumerator RenderTracer(Vector3 hitpoint)
    {
        tracer.enabled = true;
        tracer.SetPosition(0,spawn.position);
        tracer.SetPosition(1,spawn.position + hitpoint);
        yield return null;
        tracer.enabled = false;
    }

}
