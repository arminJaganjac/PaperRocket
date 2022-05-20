using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActivator : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Button button;

    void Start()
    {
        if (!AdManager.isFirstRun)
        {
            image.raycastTarget = false;
            button.interactable = false;
            Invoke(nameof(ActivateUIButtons), 1f);
        }
    }

    void ActivateUIButtons()
    {
        image.raycastTarget = true;
        button.interactable = true;
    }
}
