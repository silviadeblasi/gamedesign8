using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPowerUp : PowerUp
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            powerUpSignal.Raise();
            this.gameObject.SetActive(false);
        }
    }
}
