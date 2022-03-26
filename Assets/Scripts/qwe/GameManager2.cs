using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
[DefaultExecutionOrder(-10)]
public class GameManager2 : MonoBehaviour
{
    public Color[] colors = new Color[24];
    public static GameManager2 instance;
    public static UnityEvent Stack = new UnityEvent();
    public GameObject upperPlate;
    public GameObject lowerPlate;
    public GameObject part1;
    public GameObject part2;
    public GameObject gameOver;
    public GameObject particle;
    public float distance;
    public int score;
    public bool isGameOver;
    public bool isStart;
    public int colorCount;
    private void Awake()
    {
        instance = this;
        isStart = false;
        isGameOver = false;
    }
    void Start()
    {
        score = 0;
        colorCount = 0;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)&&isStart!=false)
        {

            //Stack.Invoke();
            Kill();
            Distance();
            Split();
            Score();
            Spawn.instance.SpawnPosition();
            Spawn.instance.Spawner();
            CameraMove.instance.Camera();
        }

    }
    /*private void OnEnable()
    {
        Stack.AddListener(Kill);
        Stack.AddListener(Distance);
        Stack.AddListener(Split);
        Stack.AddListener(Score);
        Stack.AddListener(Spawn.instance.SpawnPosition);
        Stack.AddListener(Spawn.instance.Spawner);
        Stack.AddListener(CameraMove.instance.Camera);
    }
    private void OnDisable()
    {
        Stack.RemoveListener(Kill);
        Stack.RemoveListener(Distance);
        Stack.RemoveListener(Split);
        Stack.RemoveListener(Score);
        Stack.RemoveListener(Spawn.instance.SpawnPosition);
        Stack.RemoveListener(Spawn.instance.Spawner);
        Stack.RemoveListener(CameraMove.instance.Camera);
    }*/
    public void Kill()
    {
        DOTween.KillAll(gameObject);
    }

    public void Distance()
    {

        if (upperPlate.name=="1")
        {
            lowerPlate = part1;
            distance = upperPlate.transform.position.x - lowerPlate.transform.position.x;
        }
        else
        {
            lowerPlate = part1;
            distance = upperPlate.transform.position.z - lowerPlate.transform.position.z;
            Debug.Log(distance);
        }

    }
    public void Split()
    {
        if (upperPlate.name=="0")
        {
            if (Mathf.Abs(distance) < 1f)
            {
                part1 = Instantiate(lowerPlate, lowerPlate.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                Destroy(part1.GetComponent<Movee>());
                Destroy(upperPlate);
                Particle();
                part1.AddComponent<ChangeColor>();
            }
            else
            {
                if (lowerPlate.transform.localScale.z < Mathf.Abs(distance))
                {
                    Debug.Log("SplitGameOverZGirdim");
                    isGameOver = true;
                    gameOver.SetActive(true);
                    upperPlate.AddComponent<Rigidbody>();
                }
                else
                {
                    if (distance > 0)
                    {
                        part1 = Instantiate(lowerPlate, upperPlate.transform.position - new Vector3(0, 0, distance / 2), Quaternion.identity);
                        part1.transform.localScale = new Vector3(part1.transform.localScale.x, part1.transform.localScale.y, part1.transform.localScale.z - distance);
                        part2 = Instantiate(lowerPlate, upperPlate.transform.position - new Vector3(0, 0, distance / 2) + new Vector3(0, 0, upperPlate.transform.localScale.z / 2), Quaternion.identity);
                        part2.transform.localScale = new Vector3(part2.transform.localScale.x, part2.transform.localScale.y, distance);
                        AfterSplit();
                        Debug.Log("distance>0");
                    }
                    else
                    {
                        part1 = Instantiate(lowerPlate, upperPlate.transform.position - new Vector3(0, 0, distance / 2), Quaternion.identity);
                        part1.transform.localScale = new Vector3(part1.transform.localScale.x, part1.transform.localScale.y, part1.transform.localScale.z + distance);
                        part2 = Instantiate(lowerPlate, upperPlate.transform.position - new Vector3(0, 0, distance / 2) - new Vector3(0, 0, upperPlate.transform.localScale.z / 2), Quaternion.identity);
                        part2.transform.localScale = new Vector3(part2.transform.localScale.x, part2.transform.localScale.y, distance);
                        AfterSplit();
                        Debug.Log("distance<0");
                    }
                }
            }
        }
        else
        {
            if (Mathf.Abs(distance) < 0.5f)
            {
                part1 = Instantiate(lowerPlate, lowerPlate.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                Destroy(part1.GetComponent<Movee>());
                Destroy(upperPlate);
                Particle();
                part1.AddComponent<ChangeColor>();

            }
            else
            {
                if (lowerPlate.transform.localScale.x < Mathf.Abs(distance))
                {
                    Debug.Log("SplitGameOverXGirdim");
                    isGameOver = true;
                    gameOver.SetActive(true);
                    upperPlate.AddComponent<Rigidbody>();
                }
                else
                {
                    if (distance > 0)
                    {
                        part1 = Instantiate(upperPlate, upperPlate.transform.position - new Vector3(distance / 2, 0, 0), Quaternion.identity);
                        part1.transform.localScale = new Vector3(part1.transform.localScale.x - distance, part1.transform.localScale.y, part1.transform.localScale.z);
                        part2 = Instantiate(upperPlate, upperPlate.transform.position - new Vector3(distance / 2, 0, 0) + new Vector3(upperPlate.transform.localScale.x / 2, 0, 0), Quaternion.identity);
                        part2.transform.localScale = new Vector3(distance, part2.transform.localScale.y, part2.transform.localScale.z);
                        AfterSplit();
                    }
                    else
                    {
                        part1 = Instantiate(upperPlate, upperPlate.transform.position - new Vector3(distance / 2, 0, 0), upperPlate.transform.rotation);
                        part1.transform.localScale = new Vector3(part1.transform.localScale.x + distance, part1.transform.localScale.y, part1.transform.localScale.z);
                        part2 = Instantiate(upperPlate, upperPlate.transform.position - new Vector3(distance / 2, 0, 0) - new Vector3(upperPlate.transform.localScale.x / 2, 0, 0), Quaternion.identity);
                        part2.transform.localScale = new Vector3(distance, part2.transform.localScale.y, part2.transform.localScale.z);
                        AfterSplit();
                    }
                }

            }
        }
    }
    public void Particle()
    {
        GameObject particle1 = Instantiate(particle, lowerPlate.transform.position + new Vector3(-lowerPlate.transform.localScale.x / 2, 0.5f, -lowerPlate.transform.localScale.z / 2 - 0.2f), Quaternion.identity);
        particle1.transform.DOMove(Vector3.right * lowerPlate.transform.localScale.x, 0.5f).SetRelative().OnComplete(() => { particle1.transform.DOScale(Vector3.zero, 0.2f).OnComplete(() => { Destroy(particle1); }); });
        GameObject particle2 = Instantiate(particle, lowerPlate.transform.position + new Vector3(lowerPlate.transform.localScale.x / 2, 0.5f, lowerPlate.transform.localScale.z / 2 + 0.2f), Quaternion.identity);
        particle2.transform.DOMove(Vector3.back * lowerPlate.transform.localScale.z, 0.5f).SetRelative().OnComplete(() => { particle2.transform.DOScale(Vector3.zero, 0.2f).OnComplete(() => { Destroy(particle2); }); });
    }
    public void Score()
    {
        score++;
        colorCount++;
        colorCount %= 24;
    }
    public void AfterSplit()
    {
        part1.AddComponent<ChangeColor>();
        part2.AddComponent<ChangeColor>();
        Destroy(part1.GetComponent<Movee>());
        Destroy(part2.GetComponent<Movee>());
        part2.AddComponent<Rigidbody>();
        lowerPlate = part1;
        Destroy(upperPlate);
        Destroy(part2, 3f);
    }
}

