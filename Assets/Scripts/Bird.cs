﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    private Rigidbody _rigidbody;

    public float Force;



    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log("I Jumped!");
            //_rigidbody.AddForce(new Vector3(0, 5, 0), ForceMode.VelocityChange);
            _rigidbody.velocity = new Vector3(0, Force, 0);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Renderer>().material.color = new Color(1, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("got a point");
    }
}
