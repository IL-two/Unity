using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")]
public class ItemModel : ScriptableObject
{
    new public string name = "New Item";
    public Sprite sprite = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        Debug.Log("Use" + name);
    }
}
