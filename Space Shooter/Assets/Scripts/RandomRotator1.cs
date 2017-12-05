using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator1 : MonoBehaviour {

    public float tumble;
    private Rigidbody astRb;

    void Start()
    {
        astRb = GetComponent<Rigidbody>();
        astRb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
