using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class GameOverUI : MonoBehaviour
{
    public GameObject startUI;
    private void OnEnable()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).localScale = Vector3.zero;
            if (i == gameObject.transform.childCount - 1)
            {
                for (int j = 0; j < gameObject.transform.childCount; j++)
                {
                    gameObject.transform.GetChild(j).transform.DOScale(Vector3.one,0.5f);
                }

            }
        }
    }
    public void GameOverButton()
    {
        
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (i == gameObject.transform.childCount - 1)
            {
                gameObject.transform.GetChild(i).transform.DOScale(0, 0.5f).OnComplete(() => { SceneManager.LoadScene(0); startUI.SetActive(false); gameObject.SetActive(false); });

            }
            else
            {
                gameObject.transform.GetChild(i).transform.DOScale(0, 0.5f);
            }
        }
    }
}
