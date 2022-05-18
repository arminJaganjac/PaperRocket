using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float passedTime;
    public int currentScene;
    public bool isTimerStarted;
    public bool isTutorial;
    public bool isLastLevel;

    [SerializeField] public float fuelLevel = 10f;
    [SerializeField] Slider fuelSlider;
    [SerializeField] GameObject player;

    public bool isFuelEmpty;

    void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            fuelSlider.value = fuelLevel;
        }
        SetSkin();
    }

    void Update()
    {
        if (isTimerStarted)
        {
            passedTime += Time.deltaTime;
        }
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

        if (isLastLevel)
        {
            SceneManager.LoadScene(0);
        }
        else if (currentScene == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentScene);
        }
    }

    public void LoadScene(int buildIndex)
    {
        AdManager.isFirstRun = true;
        currentScene = buildIndex;
        Time.timeScale = 1f;
        SceneManager.LoadScene(buildIndex);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void StartTime()
    {
        isTimerStarted = true;
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
