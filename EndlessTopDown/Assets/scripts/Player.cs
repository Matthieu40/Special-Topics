using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variables
    public float movementSpeed; //player movement speed
    public GameObject camera; 


    //Methods
    void Update()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position); //plane that tracks camera position
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition); //player always faces direction of cursor
        float hitDist = 0.0f;

        if(playerPlane.Raycast(ray, out hitDist))
        {
            Debug.Log("it worked");
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7f * Time.deltaTime);
        }

        //player Movement
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("it worked");
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
    }



}
