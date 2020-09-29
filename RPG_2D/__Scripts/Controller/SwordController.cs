using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{    
    private GameObject sword;
    private PlayerController dray;
    
    // Start is called before the first frame update
    void Start()
    {
        sword = GetComponentInChildren<DamageController>().gameObject;        
        dray = transform.parent.GetComponent<PlayerController>();        
        sword.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90 * dray.facing);
        sword.SetActive(dray.mode == PlayerController.eMode.attack);
    }
}
