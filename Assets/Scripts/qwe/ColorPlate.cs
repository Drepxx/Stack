using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPlate : MonoBehaviour
{
    public Color[] colors = new Color[24];
    private void Update()
    {
        gameObject.transform.GetComponent<MeshRenderer>().material.color = colors[GameManager2.instance.colorCount];
    }
}
