using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour
{
    public static float zoomToPlayerDelay = 3f;

    [SerializeField] CinemachineVirtualCamera playerCam;
    [SerializeField] CinemachineVirtualCamera levelCam;

    void Awake()
    {
        if (AdManager.isFirstRun == false)
        {
            levelCam.enabled = false;
        }
    }

    void Start()
    {
        Invoke(nameof(ZoomToPlayer), zoomToPlayerDelay);
    }

    public void ZoomToPlayer()
    {
        levelCam.enabled = false;
    }
}
