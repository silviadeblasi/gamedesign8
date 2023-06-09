using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public int numberHeld;
    public bool usable;
    public bool unique;
    public UnityEvent thisEvent;
    //[SerializeField] 
    private HeartManager heartManager;
    //[SerializeField] private PlayerHealth playerHealth;

    public void Use()
    {
        Debug.Log("Using Item");
        thisEvent.Invoke();
    }

    // public void DecreaseAmount(int amountToDecrease)
    // {
    //     numberHeld -= amountToDecrease;

    //     if(numberHeld < 0)
    //     {
    //         numberHeld = 0;
    //     }
    // }

    public void DecreaseAmount()
    {
        numberHeld--;

        if(numberHeld < 0)
        {
            numberHeld = 0;
        }
    }

    // public void UpdateHeartContainer()
    // {
    //     heartManager.UpdateHearts();
    // }
}
