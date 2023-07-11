using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Information")]
    public PlayerInventory playerInventoryList;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanelContent;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject useButton;
    [SerializeField] private GameObject player;
    public InventoryItem currentItem;
    [SerializeField] private InventoryItem machete;
    // public static bool InventoryActive = false;
    // public GameObject Inventory;

    private void Awake() 
    {
        ClearInventorySlots();
        playerInventoryList.myInventory.Add(machete);
    }

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
        if(playerInventoryList)
        {
            for(int i = 0; i < playerInventoryList.myInventory.Count; i++)
            {
                if(playerInventoryList.myInventory[i].numberHeld > 0)
                {
                    GameObject temp = Instantiate(blankInventorySlot, inventoryPanelContent.transform.position, 
                        inventoryPanelContent.transform.rotation, inventoryPanelContent.transform);
                    temp.transform.SetParent(inventoryPanelContent.transform);
                    InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                    
                    if(newSlot)
                    {
                        newSlot.Setup(playerInventoryList.myInventory[i], this);
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
        for(int i = 0; i < inventoryPanelContent.transform.childCount; i++)
        {
            Destroy(inventoryPanelContent.transform.GetChild(i).gameObject);
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
