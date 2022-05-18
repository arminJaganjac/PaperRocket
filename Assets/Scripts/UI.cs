using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject uIPanel;

    void Start()
    {
        if (AdManager.isFirstRun)
        {
            Invoke(nameof(ActivateUIPanel), CameraHandler.zoomToPlayerDelay + 2f);
        }
        else
        {
            ActivateUIPanel();
        }
    }

    void ActivateUIPanel()
    {
        uIPanel.SetActive(true);
    }
}
