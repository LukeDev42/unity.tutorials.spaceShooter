using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class PlayerController : MonoBehaviour {

    private Rigidbody shipRb;
    public float tilt;
    public float speed;
    public Boundary boundary;
    public GameObject shot;
    public float fireRate;
    private float nextFire;
    public Transform shotSpawn;
    private AudioSource boltSound;

    private void Start()
    {
        shipRb = GetComponent<Rigidbody>();
        boltSound = GetComponent<AudioSource>();
        
    }
    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            boltSound.Play();
        }
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        shipRb.velocity = movement * speed;

        shipRb.position = new Vector3
            (
                Mathf.Clamp(shipRb.position.x, boundary.xMin, boundary.xMax),
                0.0f, 
                Mathf.Clamp(shipRb.position.z, boundary.zMin, boundary.zMax)
            );

        shipRb.rotation = Quaternion.Euler(0.0f, 0.0f, shipRb.velocity.x * -tilt);
    }
}
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
