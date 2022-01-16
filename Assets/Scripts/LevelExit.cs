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
    PlayfabManager playfabManager;

    public Scene activeScene;

    private void Awake()
    {
        playfabManager = FindObjectOfType<PlayfabManager>();
        levelManager = FindObjectOfType<LevelManager>();
        gameObjects = GameObject.FindGameObjectWithTag("GameObjects");
        scoreScreen = FindObjectOfType<ScoreScreen>();
        activeScene = SceneManager.GetActiveScene();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isLevelFinished = true;
        Time.timeScale = 0f;
        scoreScreen.SetCongratulationText();
        convertedScore = Mathf.RoundToInt(levelManager.passedTime * 100f);
        SetHighScore();
        scoreScreen.SetLastScoreText(levelManager.passedTime);
        DisableGameObjects();
        if (AdManager.Instance.timePlayingTimer <= 0)
        {
            AdManager.Instance.ShowAd();
            AdManager.Instance.timePlayingTimer = 300f;
        }
        playfabManager.GetLeaderboard();
        scoreScreen.EnableScoreScreen();
    }

    void DisableGameObjects()
    {
        gameObjects.SetActive(false);
    }

    void SetHighScore()
    {
        playfabManager.SendLeaderboard(convertedScore, activeScene.name);
        if (levelManager.passedTime < PlayerPrefs.GetFloat(activeScene.name) || PlayerPrefs.GetFloat(activeScene.name) == 0)
        {
            PlayerPrefs.SetFloat(activeScene.name, levelManager.passedTime);
        }
    }
}
