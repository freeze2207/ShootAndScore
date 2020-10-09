using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletToSpawn;
    [Header("The force quantity applies to the bullet:")]
    public float magnitude = 500.0f;

    [Header("The speed quantity applies to the gun rotate:")]
    public float speed = 1.0f;

    Transform fireLocationTransform;
    Vector3 direction = new Vector3();
    GameObject bulletWillSpawn;

    private void Start()
    {
        //  Get the fire location
        fireLocationTransform = GameObject.Find("GunFireLocation").GetComponent<Transform>();

    }
    
    private void Update()
    {
        if(GamePlayManager.instance.ammo > 0)
        {
            FireBullet();
        } 
        AimingControl();
    }

    private void FireBullet()        // fire the bullet by spawning a bullet at the gun's end location when player hit space
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Get the Vector for aiming direction
            direction = Vector3.Normalize(fireLocationTransform.position - GameObject.Find("Gun").GetComponent<Transform>().position);

            // Spawn the bullet 
            bulletWillSpawn = Instantiate(bulletToSpawn, fireLocationTransform.position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            bulletWillSpawn.SetActive(true);

            //  Apply force to the bullet
            bulletWillSpawn.GetComponent<Rigidbody>().AddForce(direction * magnitude);

            GamePlayManager.instance.ammo--;
            GameObject.Find("AmmoText").GetComponent<Text>().text = "Ammo: " + GamePlayManager.instance.ammo;

        }
        
    }

    private void AimingControl()    // TODO Rotate relate to world not self
    {
        if ( Input.GetKey(KeyCode.W) )
        {
            this.transform.Rotate(-speed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Rotate(speed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {         
            this.transform.Rotate(0.0f, -speed * Time.deltaTime, 0.0f, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(0.0f, speed * Time.deltaTime, 0.0f, Space.World);
        }
    }
}
