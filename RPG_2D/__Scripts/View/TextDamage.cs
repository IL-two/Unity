using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TextDamage : MonoBehaviour
{
    public int damage;

    private TextMesh text;

    private void Start()
    {
        text = GetComponent<TextMesh>();
        text.text = damage.ToString();
    }

    public void OnAnimationOver()
    {
        Destroy(GetComponentInParent<TextDamage>().gameObject);
    }    
}
