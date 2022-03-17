using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class StartUI : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    public GameObject scoreCanvas;
    public bool a;
    private void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();
    }
    private void Update()
    {
        if (a)
        {
            StartButton();
            a = false;
        }
    }
    public void StartButton()
    {
        Spawn.instance.Spawner();
        GameManager2.instance.isStart = true;
        Spawn.instance.start = true;
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (i == gameObject.transform.childCount - 1)
            {
                gameObject.transform.GetChild(i).transform.DOScale(0, 0.5f).OnComplete(() => { gameObject.SetActive(false); });
                
            }
            else
            {
                gameObject.transform.GetChild(i).transform.DOScale(0, 0.5f).OnComplete(() => { scoreCanvas.SetActive(true); });
            }
        }
    }
}
