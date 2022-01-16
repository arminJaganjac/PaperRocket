using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] CinemachineVirtualCamera cam;

    void FixedUpdate()
    {
        float rbVelocity = rb.velocity.sqrMagnitude;
        cam.m_Lens.OrthographicSize = 10 + (rbVelocity * 0.05f);
    }
}
