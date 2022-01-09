using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float passedTime;
    int scoreMultiplier = 10;

    public int score;
    public int currentScene;
    public bool isTimerStarted;

    [SerializeField] public float fuelLevel = 10f;
    [SerializeField] Slider fuelSlider;

    public bool isFuelEmpty;

    void Start()
    {
        fuelSlider.value = fuelLevel;
    }

    void Update()
    {
        if (isTimerStarted)
        {
            passedTime += Time.deltaTime;
        }
        CalculateScore();
    }

    void FixedUpdate()
    {
        if (fuelLevel <= 0)
        {
            isFuelEmpty = true;
        }
        else
        {
            isFuelEmpty = false;
        }
    }

    public void UseFuel()
    {
        fuelLevel -= Time.fixedDeltaTime;
        fuelSlider.value = fuelLevel;
    }

    public void LoadNextLevel()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        currentScene++;
        Time.timeScale = 1f;

        if (currentScene == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentScene);
        }
    }

    void CalculateScore()
    {
        score = Mathf.RoundToInt(passedTime * scoreMultiplier);
    }

    public void StartTime()
    {
        isTimerStarted = true;
        Debug.Log(isTimerStarted);
    }
}
