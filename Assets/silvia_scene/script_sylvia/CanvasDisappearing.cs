using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasDisappearing : MonoBehaviour
{
    public GameObject panelToDisappear;
    public GameObject canvas;
    public float fadeDuration = 1f;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2f); // Opzionale: puoi aggiungere un ritardo prima che inizi a scomparire il canvas

        float elapsedTime = 0f;
        Image panelImage = panelToDisappear.GetComponent<Image>();
        Color originalColor = panelImage.color;
        Color targetColor = originalColor;
        targetColor.a = 0f; // Imposta l'alpha desiderato per la scomparsa

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration; // Calcola il valore normalizzato del tempo trascorso

            // Interpola tra il colore originale e il colore di destinazione in base al tempo
            Color lerpedColor = Color.Lerp(originalColor, targetColor, t);
            panelImage.color = lerpedColor;

            yield return null; // Attendere un frame prima di continuare
        }

        canvas.SetActive(false); // Disattiva il pannello quando ha completato la scomparsa
    }
}
