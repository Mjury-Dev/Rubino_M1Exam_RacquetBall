using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racquet : MonoBehaviour {

    public float racquetSpeed = 1f;
    private Vector3 racquetPos = new Vector3(0, -4.5f, 0);
	
	// Update is called once per frame
	void Update () {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal")) * racquetSpeed;
        racquetPos = new Vector3(Mathf.Clamp(xPos, -3.5f, 3.5f), -4.5f, 0);
        transform.position = racquetPos;
	}
}
