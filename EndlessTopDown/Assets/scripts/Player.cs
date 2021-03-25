using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variables
    public float movementSpeed; //player movement speed
    public GameObject Camera;

    public GameObject PlayerObj;

    public Gun gun;
    public float waitTime;//shooting related
    
    public float points;

    public Gun[] guns; //list of all possible guns
    private Gun currentGun;
    public Transform handHold;
    //Methods

    void Start()
    {

        EquipGun(0);
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
        if (currentGun)
        {
            if (Input.GetButtonDown("Shoot"))
            {
                currentGun.Shoot();
            }
            else if (Input.GetButton("Shoot")) //if gun is automatic, continuous shooting will be active
            {
                currentGun.ShootContinuous();
            }

            for(int i = 0; i< guns.Length; i++)
            {
                if (Input.GetKeyDown((i + 1) + "") || Input.GetKeyDown("[" + (i+1) + "]"))
                {
                    EquipGun(i);
                    break;
                }
            }
        }

        
    }


    void EquipGun(int i)
    {
        if (currentGun)
        {
            Destroy(currentGun.gameObject);
        }

        currentGun = Instantiate(guns[i], handHold.position, handHold.rotation) as Gun;
        currentGun.transform.parent = handHold;

    }

   
}
