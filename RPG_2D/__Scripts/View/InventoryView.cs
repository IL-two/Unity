using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;

    InventoryController inventory;

    InventorySlotController[] inventorySlots;
    // Start is called before the first frame update
    void Start()
    {
        inventory = InventoryController.inventory;
        inventory.onItemChangedCallBack += UpdateUI;

        inventorySlots = itemsParent.GetComponentsInChildren<InventorySlotController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryUI.activeInHierarchy)
                inventoryUI.SetActive(false);
            else
                inventoryUI.SetActive(true);
        }
    }

    void UpdateUI ()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                inventorySlots[i].AddItem(inventory.items[i]);
            }
            else
            {
                inventorySlots[i].ClearSlot();
            }
        }
    }
}
