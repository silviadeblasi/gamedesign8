using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public Transform cameraTransform; // Riferimento al transform della camera
    public GameObject main_camera; //mi serve per riattivare il codice che segue il player 
    public GameObject target;
    private float shakeDuration = 5f; // Durata dello shake
    private float shakeMagnitude = 0.5f; // Intensità dello shake

    private Vector3 originalPosition; // Posizione originale della camera

    private void Start()
    {
        originalPosition = cameraTransform.localPosition;
        ShakeCamera();
    }

    public void ShakeCamera()
    {
        // Avvia la coroutine per lo shake della camera
        StartCoroutine(ShakeCoroutine());
        main_camera.GetComponent<camera_movement>().enabled = true;
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

            elapsed += Time.deltaTime;

            yield return null;
        }

        // Ripristina la posizione originale della camera
        cameraTransform.localPosition = originalPosition;
    }
}
