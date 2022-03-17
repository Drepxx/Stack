using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    
    bool isDone;
    private void OnEnable()
    {

        gameObject.transform.GetChild(0).transform.localScale = Vector3.zero;
        gameObject.transform.GetChild(0).transform.DOScale(Vector3.one, 1f);
        
    }
    void Update()
    {
        scoreText.text = GameManager2.instance.score.ToString();
        PlayerPrefs.SetInt("HighScore", GameManager2.instance.score);
    }
}
