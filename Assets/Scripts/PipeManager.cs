using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour {

    private float _lastSpawnTime;

    public GameObject Pipe;

    private void Start()
    {
        _lastSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update () {
        if (Time.time - _lastSpawnTime > Random.Range(1f, 8))
        {
            Instantiate(Pipe, new Vector3(20,Random.Range(-3,3f)), Quaternion.Euler(0,0,0));
            _lastSpawnTime = Time.time;
        }
	}
}
