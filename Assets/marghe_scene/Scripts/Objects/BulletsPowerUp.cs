using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPowerUp : PowerUp
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            powerUpSignal.Raise();
            this.gameObject.SetActive(false);
        }
    }
}
