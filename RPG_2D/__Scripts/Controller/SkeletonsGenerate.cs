using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonsGenerate : MonoBehaviour
{
    public GameObject skeletons;
    float time = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(skeletons, transform.position, Quaternion.identity);
        Instantiate(skeletons, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {        
        if (Time.time >= time)
        {
            Instantiate(skeletons, transform.position, Quaternion.identity);
            time += 5f;
        }
    }
}
