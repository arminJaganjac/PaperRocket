using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera playerCam;
    [SerializeField] CinemachineVirtualCamera levelCam;

    void Start()
    {
        Invoke(nameof(ZoomToPlayer), 2f);
    }

    void ZoomToPlayer()
    {
        levelCam.enabled = false;
    }
}
