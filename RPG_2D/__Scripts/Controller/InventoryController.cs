using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public static InventoryController inventory;

    public List<ItemModel> items = new List<ItemModel>();

    public int count = 23;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    private void Awake()
    {
        if (inventory != null)
        {
            Debug.LogWarning("Error inventory");
            return;
        }

        inventory = this;
    }    

    public bool Add (ItemModel item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= count)
            {
                Debug.Log("Not place");
                return false;
            }
            items.Add(item);

            if (onItemChangedCallBack != null)
            {
                onItemChangedCallBack.Invoke();
            }            
        }
        return true;
    }

    public void Remove (ItemModel item)
    {
        items.Remove(item);

        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
    }
}
