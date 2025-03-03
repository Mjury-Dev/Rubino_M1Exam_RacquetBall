using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackWall : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.DeadBall();
    }
}
