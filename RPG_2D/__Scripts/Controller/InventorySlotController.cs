using UnityEngine;
using UnityEngine.UI;

public class InventorySlotController : MonoBehaviour
{
    public Image image;
    public Button removeButton;

    ItemModel item;

    public void AddItem (ItemModel newItem)
    {
        item = newItem;

        image.sprite = item.sprite;
        image.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        image.sprite = null;
        image.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        InventoryController.inventory.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
            InventoryController.inventory.Remove(item);
        }
    }
}
