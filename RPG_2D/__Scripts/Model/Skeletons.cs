using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Skeletons : Enemy
{
    [Header("Set in Inspector: Skeletons")]
    public int speed = 2;
    public float timeThinkMin = 1f;
    public float timeThinkMax = 4f;    

    [Header("Set Dynamically: Skeletons")]
    public int facing = 0;
    public float timeNextDecision = 0;
    

    protected override void Awake()
    {
        base.Awake();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeNextDecision)
        {
            DecideDirection();
        }
        rigidbody.velocity = directions[facing] * speed;

        if (health <= 0)
        {
            PlayerController dray = FindObjectOfType<PlayerController>();
            dray.CreditingExpirience(returnExperience);
            Destroy(gameObject);            
        }
    }

    void DecideDirection()
    {
        facing = UnityEngine.Random.Range(0, 4);
        timeNextDecision = Time.time + UnityEngine.Random.Range(timeThinkMin, timeThinkMax);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        PlayerController dray = collision.gameObject.GetComponent<PlayerController>();
        if (dray != null)
        {            
            dray.ChangeHealth(damage);
        }               
    }   
}
