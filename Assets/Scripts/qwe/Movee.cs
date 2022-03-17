using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movee : MonoBehaviour
{
    public static Movee instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        if (gameObject.name==("0"))
        {
            transform.DOMove(Vector3.back * 27, 1f).SetRelative().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }
        else
        {
            transform.DOMove(Vector3.right * 27, 1f).SetRelative().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }
    }

    public void Kill()
    {
        DOTween.KillAll(gameObject);
    }
}
