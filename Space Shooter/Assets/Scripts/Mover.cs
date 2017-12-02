using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    private Rigidbody boltRB;
    public float speed;
    private void Start()
    {
        boltRB = GetComponent<Rigidbody>();
        boltRB.velocity = transform.forward * speed;
    }
}
