using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickColor : MonoBehaviour
{
    public GameObject colorGenerator;
    private void Update()
    {
        
        gameObject.GetComponent<MeshRenderer>().material.color = colorGenerator.GetComponent<MeshRenderer>().material.color;
    }
}
