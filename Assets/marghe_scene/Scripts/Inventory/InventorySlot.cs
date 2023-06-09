using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [Header("UI Stuff")]
    [SerializeField] private TextMeshProUGUI itemNumberText;
    [SerializeField] private Image itemImage;
    
    
    [Header("Variables from the item")]
    public InventoryItem thisItem;
    public InventoryManager thisManager;


    public void Setup(InventoryItem newItem, InventoryManager newManager)
    {
        thisItem = newItem;
        thisManager = newManager;

        if(thisItem)
        {
            itemImage.sprite = thisItem.itemImage;
            itemNumberText.text = "" + thisItem.numberHeld;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
