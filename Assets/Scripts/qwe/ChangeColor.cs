using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.transform.GetComponent<MeshRenderer>().material.color = GameManager2.instance.colors[GameManager2.instance.colorCount];
    }
}
