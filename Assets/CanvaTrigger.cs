using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvaTrigger : MonoBehaviour
{
    public GameObject canvaInventory;

    // void Awake()
    // {
    //     canvaInventory.gameObject.SetActive(false);
    // }

    public void Update()
    {
        if(canvaInventory.gameObject.activeSelf == true)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        canvaInventory.gameObject.SetActive(false);
    }
}
