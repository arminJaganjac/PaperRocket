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
    [SerializeField] GameObject player;

    public bool isFuelEmpty;

    void Awake()
    {
        fuelSlider.value = fuelLevel;
        SetSkin();
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

    void SetSkin()
    {

        switch (PlayerPrefs.GetInt("Skin", 0))
        {
            case 0:
                player.transform.Find("Skin0").gameObject.SetActive(true);
                break;
            case 1:
                player.transform.Find("Skin1").gameObject.SetActive(true);
                break;
            case 2:
                player.transform.Find("Skin2").gameObject.SetActive(true);
                break;
        }
    }
}
