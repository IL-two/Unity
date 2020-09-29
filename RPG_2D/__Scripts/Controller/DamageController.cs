using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public int damage = -25;
    public LayerMask enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if(collision.CompareTag("Enemy"))
            {
                Skeletons skeletons = collision.gameObject.GetComponent<Skeletons>();
                skeletons.ChangeHealth(damage - PlayerController.playerController.player.Strenght);
            }
        }
    }
}
