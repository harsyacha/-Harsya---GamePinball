using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform dummyTarget; // Target transform to focus on
    public float moveSpeed = 1.0f; // Speed of moving towards the target
    public float followDuration = 4.0f; // Duration to follow the target
    public float transitionDuration = 5.0f; // Duration for transitioning to the final position
    public float maxApproachDistance = 2.0f; // Maximum distance to approach the target before transitioning
    public Vector3 finalCameraPosition = new Vector3(25.89f, 16.15f, 0.38f); // Final camera position
    public Vector3 finalCameraRotation = new Vector3(39.504f, -90.0f, 0.0f); // Final camera rotation

    private bool isFollowingTarget = false;
    private bool isTransitioning = false;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isTransitioning)
        {
            // Start moving towards the target
            StartCoroutine(MoveTowardsTarget());
        }

        if (Input.GetKeyUp(KeyCode.Space) && isFollowingTarget)
        {
            // Stop following and start transitioning to the final position
            isFollowingTarget = false;
            StartCoroutine(SmoothTransitionToFinalPosition());
        }

        if (isFollowingTarget)
        {
            // Follow the target
            FollowTarget();
        }
    }

    private IEnumerator MoveTowardsTarget()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * moveSpeed; // Slow down the movement
            transform.position = Vector3.Lerp(initialPosition, dummyTarget.position, elapsedTime);
            transform.LookAt(dummyTarget); // Optionally, make the camera look at the target

            // Check the distance to the target
            if (Vector3.Distance(transform.position, dummyTarget.position) <= maxApproachDistance)
            {
                // Stop following and start transitioning to the final position
                isFollowingTarget = false;
                StartCoroutine(SmoothTransitionToFinalPosition());
                yield break;
            }

            yield return null;
        }

        // Ensure the camera is exactly at the target position
        transform.position = dummyTarget.position;
        transform.LookAt(dummyTarget); // Optionally, make the camera look at the target

        // Start following the target
        isFollowingTarget = true;

        // Wait for the follow duration
        yield return new WaitForSeconds(followDuration);

        // Stop following after the duration
        isFollowingTarget = false;

        // Start transitioning to the final position
        StartCoroutine(SmoothTransitionToFinalPosition());
    }

    private void FollowTarget()
    {
        // Update camera position to follow the target
        transform.position = dummyTarget.position;
        transform.LookAt(dummyTarget); // Optionally, make the camera look at the target
    }

    private IEnumerator SmoothTransitionToFinalPosition()
    {
        isTransitioning = true;
        Vector3 startPosition = transform.position;
        Quaternion startRotation = transform.rotation;
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / transitionDuration);

            // Smoothly interpolate position and rotation
            transform.position = Vector3.Lerp(startPosition, finalCameraPosition, t);
            transform.rotation = Quaternion.Lerp(startRotation, Quaternion.Euler(finalCameraRotation), t);

            yield return null;
        }

        // Ensure the camera is exactly at the final position and rotation
        transform.position = finalCameraPosition;
        transform.rotation = Quaternion.Euler(finalCameraRotation);

        isTransitioning = false;
    }
}
