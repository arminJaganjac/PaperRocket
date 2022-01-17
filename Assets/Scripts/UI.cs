using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject uIPanel;

    void Start()
    {
        Invoke(nameof(ActivateUIPanel), 4f);
    }

    void ActivateUIPanel()
    {
        uIPanel.SetActive(true);
    }
}
