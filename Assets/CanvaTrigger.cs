using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvaTrigger : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Active");
        gameObject.SetActive(true);
        StartCoroutine(Wait());
        gameObject.SetActive(false);  
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}
