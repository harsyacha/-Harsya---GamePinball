using System.Collections;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public Collider bola;
    public KeyCode input;
    public float maxTimeHold;
    public float maxForce;
    public Color holdColor = Color.red;
    public Color defaultColor = Color.white;

    private bool isHold = false;
    private Renderer launcherRenderer;
    private Rigidbody bolaRigidbody;
    private float holdForce;

    private void Start()
    {
        launcherRenderer = GetComponent<Renderer>();
        if (launcherRenderer != null)
        {
            launcherRenderer.material.color = defaultColor;
        }
        // Assuming the bola collider is attached to an object with a Rigidbody
        if (bola != null)
        {
            bolaRigidbody = bola.GetComponent<Rigidbody>();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == bola)
        {
            ReadInput(collision.collider);
        }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input) && !isHold)
        {
            StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;
        holdForce = 0.0f; // Initialize holdForce

        if (launcherRenderer != null)
        {
            launcherRenderer.material.color = holdColor;
        }

        float timeHold = 0.0f;

        while (Input.GetKey(input))
        {
            // Calculate the force to apply
            holdForce = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);

            // Calculate direction to apply force
            Vector3 direction = (collider.transform.position - transform.position).normalized;
            direction.y = 0; // Ensure the force is applied only horizontally

            timeHold += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        // Apply force to the bola after the input is released
        if (bolaRigidbody != null && holdForce > 0)
        {
            Vector3 finalDirection = (collider.transform.position - transform.position).normalized;
            finalDirection.y = 0;
            bolaRigidbody.AddForce(finalDirection * holdForce);
        }

        if (launcherRenderer != null)
        {
            launcherRenderer.material.color = defaultColor;
        }

        isHold = false;
    }
}
