using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject sword;
    public GameObject bow;

    public GameObject swordChoicse;
    public GameObject bowChoicse;

    // Update is called once per frame
    private void Start()
    {
        sword.SetActive(true);
        swordChoicse.SetActive(true);

        bow.SetActive(false);
        bowChoicse.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (bow.activeInHierarchy == true)
            {
                bow.SetActive(false);
                bowChoicse.SetActive(false);

                sword.SetActive(true);
                swordChoicse.SetActive(true);
            }
            else if (sword.activeInHierarchy == true)
            {
                bow.SetActive(true);
                bowChoicse.SetActive(true);

                sword.SetActive(false);
                swordChoicse.SetActive(false);
            }
        }
    }
}
