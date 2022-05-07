using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    public static CameraMove instance;
    public Vector3 desiredPosition;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        desiredPosition = transform.position;
    }
    private void LateUpdate()
    {
        Vector3 smoothedPosition = Vector3.Lerp(gameObject.transform.position, desiredPosition, 0.0125f);
        transform.position = smoothedPosition;
    }
    public void Camera()
    {
        desiredPosition = transform.position + new Vector3(0f, 1f, 0f);
    }
}
