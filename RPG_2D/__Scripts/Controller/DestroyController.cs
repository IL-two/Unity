using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour
{
    public void Start()
    {
        Destroy(gameObject, 1.5f);
    }
}
