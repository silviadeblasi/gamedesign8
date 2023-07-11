using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useButtoncanva : MonoBehaviour
{
    public GameObject inventoryCanvas;

    void Update()
    {
        if(gameObject.activeSelf == true)
        {
            inventoryCanvas.SetActive(false);
        }
    }
}
