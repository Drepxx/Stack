using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ColorGenerator : MonoBehaviour
{
    public GameObject colorGen;
    public Material matColor;
    
    public Color blue;
    public Color red;
    public Color yellow;
    public Color green;
    void Start()
    {
        matColor.color = blue;
        ColorGen();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ColorGen();
        }
       // colorGen.GetComponent<MeshRenderer>().material.color=
    }
    public void ColorGen()
    {
        colorGen.GetComponent<MeshRenderer>().material.DOColor(green, 5f).OnComplete(() => { colorGen.GetComponent<MeshRenderer>().material.DOColor(red, 5f).OnComplete(() => { colorGen.GetComponent<MeshRenderer>().material.DOColor(yellow, 5f).OnComplete(() => { colorGen.GetComponent<MeshRenderer>().material.DOColor(green, 5f).OnComplete(() => { colorGen.GetComponent<MeshRenderer>().material.DOColor(blue, 5f).OnComplete(() => { ColorGen(); }); }); }); }); });
    }
}
