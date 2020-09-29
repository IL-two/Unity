using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollect : MonoBehaviour
{
    public ItemModel item;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController dray = collision.GetComponent<PlayerController>();
        if (dray != null)
        {                       
            bool isSelect = InventoryController.inventory.Add(item);
            Debug.Log("Object enter " + collision);

            if (isSelect)
            {
                Destroy(gameObject);
            }
        }
    }
}
