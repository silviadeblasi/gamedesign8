using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public Transform cameraTransform; // Riferimento al transform della camera
    public float shakeDuration = 15f; // Durata dello shake
    public float shakeMagnitude = 0.5f; // Intensità dello shake

    private Vector3 originalPosition; // Posizione originale della camera

    private void Start()
    {
        originalPosition = new Vector3 (0,0,0);
    }

    public void ShakeCamera()
    {
        // Avvia la coroutine per lo shake della camera
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            // Genera uno spostamento casuale all'interno di un cerchio
            Vector3 randomOffset = Random.insideUnitCircle * shakeMagnitude;

            // Applica lo spostamento casuale alla posizione della camera
            cameraTransform.localPosition = originalPosition + randomOffset;

            elapsed += 0.1f;

        }

        // Ripristina la posizione originale della camera
        cameraTransform.localPosition = originalPosition;
        yield return null;
    }
}
