using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Health")]
public class HealthModel : ItemModel
{
    public int Health = 20;

    public override void Use()
    {
        base.Use();

        PlayerController.playerController.ChangeHealth(Health);
    }
}
