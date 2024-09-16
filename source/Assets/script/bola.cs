using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public float horizontalBounceFactor = 1.0f;
    public float maxSpeed = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 velocity = rb.velocity;
        velocity.y = 0;
        rb.velocity = velocity;

        Vector3 horizontalBounce = new Vector3(velocity.x * horizontalBounceFactor, 0, velocity.z * horizontalBounceFactor);
        rb.velocity = horizontalBounce;
    }

    void OnCollisionStay(Collision collision)
    {
        Vector3 velocity = rb.velocity;
        velocity.y = 0;
        rb.velocity = velocity;
    }
}
