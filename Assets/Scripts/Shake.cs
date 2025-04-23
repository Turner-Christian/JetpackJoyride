using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour
{
    public float shakeDuration = 1f; // Duration of the shake effect
    public bool start = false; // Flag to check if shaking is active
    public AnimationCurve shakeCurve; // Animation curve for controlling the shake effect
    // Update is called once per frame
    void Update()
    {
        if(start) {
            start = false; // Reset the start flag
            StartCoroutine(Shaking()); // Start the shaking coroutine
        }
    }

    IEnumerator Shaking() {
        Vector3 originalPosition = transform.position; // Store the original position of the object
        float elapsedTime = 0f; // Time elapsed since the shake started

        while (elapsedTime < shakeDuration) {
            elapsedTime += Time.deltaTime; // Increment elapsed time
            float strength = shakeCurve.Evaluate(elapsedTime / shakeDuration); // Evaluate the shake curve
            transform.position = originalPosition + Random.insideUnitSphere * strength; // Apply random shake effect
            yield return null; // Wait for the next frame
        }

        transform.position = originalPosition; // Reset the position to the original after shaking
    }
}
