using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird : MonoBehaviour {

    private Rigidbody _rigidbody;
    private bool _dead = false;
    private int _scoreValue = 0;

    public float Force;
    public Text Score;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && !_dead)
        {
            // Debug.Log("I Jumped!");
            //_rigidbody.AddForce(new Vector3(0, 5, 0), ForceMode.VelocityChange);
            _rigidbody.velocity = new Vector3(0, Force, 0);
        }
        if (_dead && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("game");
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Renderer>().material.color = new Color(1, 0, 0);
        _dead = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log($"got a point {_score}");
        _scoreValue++;
        Score.text = string.Format("Score: {0}", _scoreValue);
    }
}
