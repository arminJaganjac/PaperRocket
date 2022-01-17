using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject userNamePanel;
    [SerializeField] GameObject mainMenuPanel;

    void Start()
    {
        if (PlayerPrefs.GetString("Username", null).Length > 0)
        {
            Debug.Log(PlayerPrefs.GetString("Username"));
            userNamePanel.SetActive(false);
            mainMenuPanel.SetActive(true);
        }
    }
}
