/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public RectTransform playerInMap;
    public RectTransform map2dEnd;
    public Transform map3dParent;
    public Transform map3dEnd;

    private Vector3 normalized, mapped;

    private void Update()
    {
        normalized = Divide(
                map3dParent.InverseTransformPoint(this.transform.position),
                map3dEnd.position - map3dParent.position
            );
        normalized.y = normalized.z;
        mapped = Multiply(normalized, map2dEnd.localPosition);
        mapped.z = 0;
        playerInMap.localPosition = mapped;
    }

    private static Vector3 Divide(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
    }

    private static Vector3 Multiply(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    }
}*/

using UnityEngine;

public class Minimap : MonoBehaviour
{
    public RectTransform playerInMap;
    public RectTransform mainMap;
    public RectTransform minimap;

    private void Update()
    {
        // Calcola la posizione normalizzata del giocatore sulla mappa principale
        Vector3 normalizedPosition = mainMap.InverseTransformPoint(transform.position);

        // Calcola la posizione mappata del giocatore sulla minimappa
        Vector2 mappedPosition = new Vector2(
            normalizedPosition.x / mainMap.rect.width * minimap.rect.width,
            normalizedPosition.y / mainMap.rect.height * minimap.rect.height
        );

        // Aggiorna la posizione del giocatore sulla minimappa
        playerInMap.localPosition = mappedPosition;
    }
}




