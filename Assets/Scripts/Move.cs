using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move : MonoBehaviour
{
    void Start()
    {
        if (gameObject==GameManager.instance.newInst)
        {
        transform.DOMove(Vector3.back * 27, 1f).SetRelative().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }
        else
        {
        if (SpawnPoint.instance.count %2==0)
        {
        transform.DOMove(Vector3.back * 27, 1f).SetRelative().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }
        else
        {
        transform.DOMove(Vector3.right * 27, 1f).SetRelative().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }
        }
        
    }
    /*private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            DOTween.KillAll(gameObject);
        }
    }*/
    private void OnEnable()
    {
        GameManager.Split.AddListener(KillMove);
    }
    private void OnDisable()
    {
        GameManager.Split.RemoveListener(KillMove);
    }
    public void KillMove()
    {
        DOTween.KillAll(gameObject);
    }
}
