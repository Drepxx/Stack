using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public static Spawn instance;
    public GameObject[] spawns = new GameObject[2];
    public GameObject colorGenerator;
    public int count;
    public bool spawn;
    private void Awake()
    {
        instance = this;
        spawn = false;
        count = 0;
    }
    public void SpawnPosition()
    {
        spawns[0].transform.position = GameManager2.instance.part1.transform.position + new Vector3(0, 1, 15);
        spawns[1].transform.position = GameManager2.instance.part1.transform.position + new Vector3(-15, 1, 0);
    }
    public void Spawner()
    {
        if (GameManager2.instance.isGameOver ==false)
        {
            if (count == 0)
            {
                GameManager2.instance.upperPlate = Instantiate(GameManager2.instance.lowerPlate, spawns[0].transform.position, GameManager2.instance.lowerPlate.transform.rotation);
                GameManager2.instance.upperPlate.AddComponent<Movee>();
                GameManager2.instance.upperPlate.name = ("0");
                GameManager2.instance.upperPlate.GetComponent<MeshRenderer>().material.color = GameManager2.instance.colors[GameManager2.instance.colorCount];
                count = 1;
                }
            else
            {
                GameManager2.instance.upperPlate = Instantiate(GameManager2.instance.lowerPlate, spawns[1].transform.position, GameManager2.instance.lowerPlate.transform.rotation);
                GameManager2.instance.upperPlate.AddComponent<Movee>();
                GameManager2.instance.upperPlate.name = ("1");
                GameManager2.instance.upperPlate.GetComponent<MeshRenderer>().material.color = GameManager2.instance.colors[GameManager2.instance.colorCount];
                count = 0;
            }
        }
    }
}
