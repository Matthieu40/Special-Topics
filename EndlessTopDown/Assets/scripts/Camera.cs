using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //variables
    public Transform player;
    public float smooth = 0.3f; //camera smoothness

    public float height;

    private Vector3 velocity = Vector3.zero; //sets camera velocity to 0 when afk

   //Methods
   void Update()
    {
        Vector3 pos = new Vector3();
        pos.x = player.position.x;
        pos.z = player.position.z - 7f; //how far the camera is behind the player (without 4f, camera is above player.)
        pos.y = player.position.y + height; //The + height lets the camera height be manipulated
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
    }

}
