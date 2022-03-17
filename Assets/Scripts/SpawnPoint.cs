using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnPoint : MonoBehaviour
{
    public static SpawnPoint instance;
    public GameObject spawn0;
    public GameObject spawn1;
    public float count=1;
    private void Awake()
    {
        instance = this;
    }
    public void SpawnPos()
    {
            spawn0.transform.position = GameManager.instance.part1.transform.position + new Vector3(0, 1, 15);
            spawn1.transform.position = GameManager.instance.part1.transform.position + new Vector3(-15, 1, 0);
    }
    public void Spawn()
    {
        if (count== 0)
        {
            Debug.Log("sadlkfasdf");
            GameManager.instance.upperPlate = Instantiate(GameManager.instance.part1, spawn0.transform.position, Quaternion.identity);
            GameManager.instance.upperPlate.AddComponent<Move>();
            count++;
        }
        else
        {
            GameManager.instance.upperPlate = Instantiate(GameManager.instance.part1, spawn1.transform.position, Quaternion.identity);
            GameManager.instance.upperPlate.AddComponent<Move>();
            count=0;

        }
    }
}
