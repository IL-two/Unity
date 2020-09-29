using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppowShoot : MonoBehaviour
{
    public int damage = -15;
    public float speed;
    public float distance;

    public LayerMask layer;
        
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, distance, layer);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<Skeletons>().ChangeHealth(damage - PlayerController.playerController.player.Dexterity);
            }
            Destroy(gameObject);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision != null)
    //    {
    //        Skeletons skeletons = collision.gameObject.GetComponent<Skeletons>();
    //        if (skeletons != null)
    //        {
    //            skeletons.ChangeHealth(damage);
    //        }
    //        Destroy(gameObject);
    //    }
    //}
}
