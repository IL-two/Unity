using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    protected static Vector3[] directions = new Vector3[]
        {Vector3.right, Vector3.up, Vector3.left, Vector3.down};

    [Header("Set in Inspector: Enemy")]
    public int maxHealth = 100;
    public int damage = -20;
    public int returnExperience = 100;

    [Header("Set in dynamically: Enemy")]
    public int health;
    public GameObject Effect;
    public GameObject textDamage;
    
    protected Slider slider;
    protected Animator animator;
    protected new Rigidbody2D rigidbody;
    protected SpriteRenderer spriteRenderer;

    protected virtual void Awake()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        slider = GetComponentInChildren<Slider>();
        slider.maxValue = maxHealth;
        slider.value = health;
    }
    public void ChangeHealth(int ammoutn)
    {
        health = Mathf.Clamp(health + ammoutn, 0, maxHealth);
        Instantiate(Effect, transform.position, Quaternion.identity);
        slider.value = health;
        Vector2 damagePos = new Vector2(transform.position.x, transform.position.y + 1f);
        textDamage.GetComponentInChildren<TextDamage>().damage = ammoutn;
        Instantiate(textDamage, damagePos, Quaternion.identity);        
        print("Enemy:" + health + "/" + maxHealth);        
    }

}
