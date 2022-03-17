using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static UnityEvent Split = new UnityEvent();
    public GameObject[] spawns = new GameObject[2];
    public GameObject prefab;
    public GameObject startPlate;
    public GameObject lowerPlate;
    public GameObject upperPlate;
    public GameObject newInst;
    public GameObject part1;
    public GameObject part2;
    public float distance;
    public float count;
    public bool a = false;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        count = 0;
        newInst = Instantiate(prefab, spawns[0].transform.position, Quaternion.identity);
    }
    private void Update()
    {
        if (a)
        {
            Split.Invoke();
            count = 1;
            a = false;
        }
    }
    private void OnEnable()
    {
        Split.AddListener(StartDistance);
        Split.AddListener(SplitZ);
        //Split.AddListener(SpawnPoint.instance.SpawnPos);
        Split.AddListener(Spawn);
    }
    private void OnDisable()
    {
        Split.RemoveListener(StartDistance);
        Split.RemoveListener(SplitZ);
        //Split.RemoveListener(SpawnPoint.instance.SpawnPos);
        Split.RemoveListener(Spawn);
    }
    public void StartDistance()
    {
        if (count == 0)
        {
            upperPlate = newInst;
            distance = upperPlate.transform.position.z - startPlate.transform.position.z;
            Debug.Log(distance);
            count=1;
        }
        else
        {
            if (SpawnPoint.instance.count == 1)
            {
                lowerPlate = part1;
                distance = upperPlate.transform.position.x - lowerPlate.transform.position.x;
                Debug.Log(distance);
            }
            else
            {
                lowerPlate = part1;
                distance = upperPlate.transform.position.z - lowerPlate.transform.position.z;
                Debug.Log(distance);
            }
        }
    }
    public void SplitZ()
    {
        if (newInst != null && SpawnPoint.instance.count == 1)
        {
            if (distance > 0)
            {
                part1 = Instantiate(startPlate, upperPlate.transform.position - new Vector3(0, 0, distance / 2), Quaternion.identity);
                part1.transform.localScale = new Vector3(part1.transform.localScale.x, part1.transform.localScale.y, part1.transform.localScale.z - distance);
                spawns[0].transform.position = GameManager.instance.part1.transform.position + new Vector3(0, 1, 15);
                part2 = Instantiate(startPlate, upperPlate.transform.position - new Vector3(0, 0, distance / 2) + new Vector3(0, 0, upperPlate.transform.localScale.z / 2), Quaternion.identity);
                part2.transform.localScale = new Vector3(part2.transform.localScale.x, part2.transform.localScale.y, distance);
                spawns[1].transform.position = GameManager.instance.part1.transform.position + new Vector3(-15, 1, 0);
                part2.AddComponent<Rigidbody>();
                lowerPlate = part1;
                Destroy(newInst);
                Destroy(part2, 3f);
                Debug.Log("distance>0 ve Spawn0");
            }
            else
            {
                part1 = Instantiate(startPlate, upperPlate.transform.position - new Vector3(0, 0, distance / 2), Quaternion.identity);
                part1.transform.localScale = new Vector3(part1.transform.localScale.x, part1.transform.localScale.y, part1.transform.localScale.z + distance);
                spawns[0].transform.position = GameManager.instance.part1.transform.position + new Vector3(0, 1, 15);
                part2 = Instantiate(startPlate, upperPlate.transform.position - new Vector3(0, 0, distance / 2) - new Vector3(0, 0, upperPlate.transform.localScale.z / 2), Quaternion.identity);
                part2.transform.localScale = new Vector3(part2.transform.localScale.x, part2.transform.localScale.y, distance);
                spawns[1].transform.position = GameManager.instance.part1.transform.position + new Vector3(-15, 1, 0);
                lowerPlate = part1;
                part2.AddComponent<Rigidbody>();
                Destroy(newInst);
                Destroy(part2, 3f);
                Debug.Log("distance<0 ve Spawn0");

            }
        }
        else
        {
            if (distance > 0)
            {
                part1 = Instantiate(startPlate, upperPlate.transform.position - new Vector3(distance / 2, 0, 0), Quaternion.identity);
                part1.transform.localScale = new Vector3(part1.transform.localScale.x - distance, part1.transform.localScale.y, part1.transform.localScale.z);
                spawns[0].transform.position = GameManager.instance.part1.transform.position + new Vector3(0, 1, 15);
                part2 = Instantiate(startPlate, upperPlate.transform.position - new Vector3(distance / 2, 0, 0) + new Vector3(upperPlate.transform.localScale.z / 2, 0, 0), Quaternion.identity);
                part2.transform.localScale = new Vector3(distance, part2.transform.localScale.y, part2.transform.localScale.z);
                spawns[1].transform.position = GameManager.instance.part1.transform.position + new Vector3(-15, 1, 0);
                part2.AddComponent<Rigidbody>();
                lowerPlate = part1;
                Debug.Log("distance>0 ve Spawn1");

                part1.name = ("part1");
                Destroy(part2, 3f);
            }
            else
            {
                part1 = Instantiate(startPlate, upperPlate.transform.position - new Vector3(distance / 2, 0, 0),startPlate.transform.rotation);
                part1.transform.localScale = new Vector3(part1.transform.localScale.x + distance, part1.transform.localScale.y, part1.transform.localScale.z);
                spawns[0].transform.position = GameManager.instance.part1.transform.position + new Vector3(0, 1, 15);
                part2 = Instantiate(startPlate, upperPlate.transform.position - new Vector3(distance / 2, 0, 0) - new Vector3(upperPlate.transform.localScale.z / 2, 0, 0), Quaternion.identity);
                part2.transform.localScale = new Vector3(distance, part2.transform.localScale.y, part2.transform.localScale.x);
                spawns[1].transform.position = GameManager.instance.part1.transform.position + new Vector3(-15, 1, 0);
                lowerPlate = part1;
                Debug.Log("distance<0ve Spawn1");

                part2.AddComponent<Rigidbody>();
                Destroy(newInst);
                Destroy(part2, 3f);
            }
        }

    }
    public void Spawn()
    {
        if (SpawnPoint.instance.count == 0)
        {
            Debug.Log("sadlkfasdf");
            GameManager.instance.upperPlate = Instantiate(GameManager.instance.part1, spawns[0].transform.position, Quaternion.identity);
            GameManager.instance.upperPlate.AddComponent<Move>();
            count++;
        }
        else
        {
            GameManager.instance.upperPlate = Instantiate(GameManager.instance.part1, spawns[1].transform.position, Quaternion.identity);
            GameManager.instance.upperPlate.AddComponent<Move>();
            count = 0;

        }
    }
}
