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
    public Text MaxScore;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        MaxScore.text = string.Format("Max Score: {0}", PlayerPrefs.GetInt("maxscore", 0));
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
        var maxScore = PlayerPrefs.GetInt("maxscore", 0);
        if (_scoreValue > maxScore)
            PlayerPrefs.SetInt("maxscore", _scoreValue);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_dead)
        {
            _scoreValue++;
            Score.text = string.Format("Score: {0}", _scoreValue);
        }
    }
}
