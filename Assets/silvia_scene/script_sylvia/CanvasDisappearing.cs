using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasDisappearing : MonoBehaviour
{
    public GameObject panelToDisappear;
    public GameObject canvasToDisappear; // Riferimento al canvas da far scomparire
    public GameObject canvas;
    public float fadeDuration = 1f;

    private void Update() {
        if(canvasToDisappear.activeSelf == true){
            StartCoroutine(routine_damage());
        }
    }



    private IEnumerator routine_damage()
    {
        yield return new WaitForSeconds(1.5f); // Opzionale: puoi aggiungere un ritardo prima che inizi a scomparire il canvas
        fadeDuration = 1f;
        float elapsedTime = 0f;
        Image panelImage = panelToDisappear.GetComponent<Image>();
        Color originalColor = panelImage.color;
        Color targetColor = originalColor;
        targetColor.a = 0f; // Imposta l'alpha desiderato per la scomparsa

        while (elapsedTime < fadeDuration)
        {
            Debug.Log("Sono nel while");
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration; // Calcola il valore normalizzato del tempo trascorso
            Debug.Log("t: " + t);
            // Interpola tra il colore originale e il colore di destinazione in base al tempo
            Color lerpedColor = Color.Lerp(originalColor, targetColor, t);
            panelImage.color = lerpedColor;
            Debug.Log("panelImage.color: " + panelImage.color);
            yield return null; // Attendere un frame prima di continuare
        }
        
        //canvas.SetActive(false); // Disattiva il pannello quando ha completato la scomparsa
        canvasToDisappear.SetActive(false); // Disattiva il canvas quando ha completato la scomparsa
        panelImage.color = originalColor; //reimposto alpha a 1 per i danni successivi 
    }
}
