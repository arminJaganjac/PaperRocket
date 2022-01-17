using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject uIPanel;
    [SerializeField] Slider slider;
    [SerializeField] Image accelerationButton;

    LevelManager levelManager;

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        scoreText.SetText(levelManager.passedTime.ToString("F1"));
        slider.value = levelManager.fuelLevel;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
