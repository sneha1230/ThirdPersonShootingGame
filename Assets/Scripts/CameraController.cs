using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private CinemachineComposer composer;
    float speed=1.0f;

    private void Start()
    {
        composer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineComposer>();
    }
    private void Update()
    {
        float vertical = Input.GetAxis("Mouse Y") * speed;
        composer.m_TrackedObjectOffset.y += vertical;
        composer.m_TrackedObjectOffset.y += Mathf.Clamp(composer.m_TrackedObjectOffset.y, -1.0f, 1.0f);
    }
}
