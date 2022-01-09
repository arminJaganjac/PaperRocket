using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject uIPanel;
    [SerializeField] Slider slider;

    LevelManager levelManager;

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Start()
    {
        Invoke(nameof(ActivateUIPanel), 4f);
    }

    void Update()
    {
        scoreText.SetText(levelManager.score.ToString());
        slider.value = levelManager.fuelLevel;
    }

    void ActivateUIPanel()
    {
        uIPanel.SetActive(true);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}