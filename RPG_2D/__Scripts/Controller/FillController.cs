﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillController : MonoBehaviour
{
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value <= 0)
        {
            slider.fillRect.gameObject.SetActive(false);
        }
        else if (slider.value > 0)
        {
            slider.fillRect.gameObject.SetActive(true);
        }
    }
}
