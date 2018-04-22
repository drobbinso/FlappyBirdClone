using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

    public float MoveSpeed;

	void Update () {
        transform.Translate(new Vector3(MoveSpeed*Time.deltaTime, 0, 0));
        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
	}
}
