using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    int convertedScore;
    public bool isLevelFinished;

    GameObject gameObjects;
    ScoreScreen scoreScreen;
    LevelManager levelManager;


    public Scene activeScene;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        gameObjects = GameObject.FindGameObjectWithTag("GameObjects");
        scoreScreen = FindObjectOfType<ScoreScreen>();
        activeScene = SceneManager.GetActiveScene();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isLevelFinished = true;
        Time.timeScale = 0f;
        DisableGameObjects();
        scoreScreen.SetCongratulationText();
        SetHighScore();
        scoreScreen.SetLastScoreText(levelManager.passedTime);
        scoreScreen.SetHighScoreText();
        if (AdManager.Instance.timePlayingTimer <= 0)
        {
            AdManager.Instance.ShowAd();
            AdManager.Instance.timePlayingTimer = 300f;
        }
        scoreScreen.EnableScoreScreen();
    }

    void DisableGameObjects()
    {
        gameObjects.SetActive(false);
    }

    void SetHighScore()
    {
        if (levelManager.passedTime < PlayerPrefs.GetFloat(activeScene.name) || PlayerPrefs.GetFloat(activeScene.name) == 0)
        {
            PlayerPrefs.SetFloat(activeScene.name, levelManager.passedTime);
        }
    }
}
