using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalInventoryItem : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryItem thisItem;
    [SerializeField] private GameObject canvaInventory;

    private void Awake()
    {
        canvaInventory.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {    
        if(other.gameObject.CompareTag("Player") && !other.isTrigger)
        {
            canvaInventory.gameObject.SetActive(true);
            AddItemToInventory();
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }

    void AddItemToInventory()
    {
        if(playerInventory && thisItem)
        {
            if(playerInventory.myInventory.Contains(thisItem))
            {
                thisItem.numberHeld += 1;
            }
            else
            {
                playerInventory.myInventory.Add(thisItem);
                thisItem.numberHeld += 1;
            }
        }
    }
}
