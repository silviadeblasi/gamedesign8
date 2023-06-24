using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Information")]
    public PlayerInventory playerInventory;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject useButton;
    [SerializeField] private GameObject player;
    public InventoryItem currentItem;

    //private void Update()
    //{
    //    if(Input.GetButtonDown("Inventory"))
    //    {
    //        if(inventoryPanel.activeInHierarchy)
    //        {
    //            inventoryPanel.SetActive(false);
    //            player.GetComponent<PlayerMovement>().currentState = PlayerState.walk;
    //        }
    //        else
    //        {
    //            inventoryPanel.SetActive(true);
    //            player.GetComponent<PlayerMovement>().currentState = PlayerState.interact;
    //        }
    //    }
    //}

    public void SetTextAndButton(string description, bool buttonActive)
    {
        descriptionText.text = description;
        if(buttonActive)
        {
            useButton.SetActive(true);
        }
        else
        {
            useButton.SetActive(false);
        }
    }

    void MakeInventorySlots()
    {
        if(playerInventory)
        {
            for(int i = 0; i < playerInventory.myInventory.Count; i++)
            {
                if(playerInventory.myInventory[i].numberHeld > 0)
                {
                    GameObject temp = Instantiate(blankInventorySlot, 
                        inventoryPanel.transform.position, inventoryPanel.transform.rotation, inventoryPanel.transform);
                    temp.transform.SetParent(inventoryPanel.transform);
                    InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                    
                    if(newSlot)
                    {
                        newSlot.Setup(playerInventory.myInventory[i], this);
                    }
                }
            }
        }
    }

    private void OnEnable() 
    {
        ClearInventorySlots();
        MakeInventorySlots();
        Debug.Log("Inventory Manager Start");
        SetTextAndButton("", false);
    }

    public void SetupDescriptionAndButton(string newDescriptionString, bool isButtonUsable, InventoryItem newItem)
    {
        currentItem = newItem;
        descriptionText.text = newDescriptionString;
        useButton.SetActive(isButtonUsable);
    }

    void ClearInventorySlots()
    {
        for(int i = 0; i < inventoryPanel.transform.childCount; i++)
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }

    public void UseButtonPressed()
    {
        if(currentItem)
        {
            currentItem.Use();
            //Clear all the inveotry slots
            ClearInventorySlots();
            //Refill all slots with new numbers
            MakeInventorySlots();

            if(currentItem.numberHeld == 0)
            {
                SetTextAndButton("", false);
            }
        }
    }
}
