using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsCanvas : MonoBehaviour
{
    public GameObject canvaBullets;

    void Awake()
    {
        canvaBullets.gameObject.SetActive(false);
    }

    public void Update()
    {
        if(canvaBullets.gameObject.activeSelf == true)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        canvaBullets.gameObject.SetActive(false);
    }
}
