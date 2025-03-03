using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballInitVelocity = 300f;
    private Rigidbody rb;
    private bool ballInPlay = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !ballInPlay)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitVelocity, ballInitVelocity, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Racquet"))
        {
            GameManager.instance.AddCount();
        }
    }
}
