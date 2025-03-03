using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.instance.DeadBall();
    }
}
