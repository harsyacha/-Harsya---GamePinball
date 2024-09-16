using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public Collider bola;
    public float bounceForce = 500f;
    public float score;
    private Animator animator;
    public AudioManager audioManager;
    public vfxManager vfxManager;
    public ScoreManager scoreManager;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Debug.Log("kena bola");

            if (animator != null)
            {
                animator.SetTrigger("hit");
            }

            Rigidbody bolaRigidbody = bola.GetComponent<Rigidbody>();
            if (bolaRigidbody != null)
            {
                Vector3 collisionNormal = collision.GetContact(0).normal;
                collisionNormal.y = 0;
                collisionNormal.Normalize();
                bolaRigidbody.AddForce(-collisionNormal * bounceForce);
            }

            audioManager.PlaySFX(collision.transform.position);

            vfxManager.PlayVFX(collision.transform.position);
            scoreManager.AddScore(score);

        }
    }
}
