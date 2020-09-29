using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    public GameObject arrow;

    private PlayerController dray;
    private GameObject bow;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {   
        bow = transform.Find("Bow").gameObject;
        dray = transform.parent.GetComponent<PlayerController>();        
        animator = GetComponentInChildren<Animator>();
        animator.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90 * dray.facing);
        if (dray.mode != PlayerController.eMode.attack) animator.speed = 0;
    }

    public void Attack()
    {
        Instantiate(arrow, bow.transform.position, bow.transform.rotation);
        animator.CrossFade("BowAttack", 0);
        animator.speed = 1;
    }
}
