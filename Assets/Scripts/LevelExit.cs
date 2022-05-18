using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    int convertedScore;
    public bool isLevelFinished;

    GameObject gameObjects;
    [SerializeField] ScoreScreen scoreScreen;
    [SerializeField] LevelManager levelManager;
    [SerializeField] GameObject uIPanel;

    public Scene activeScene;

    private void Awake()
    {
        gameObjects = GameObject.FindGameObjectWithTag("GameObjects");
        activeScene = SceneManager.GetActiveScene();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        AdManager.isFirstRun = true;
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
        scoreScreen.EnableScoreScreen();
        uIPanel.SetActive(false);
    }

    void DisableGameObjects()
    {
        gameObjects.SetActive(false);
    }

    void SetHighScore()
    {
        SendLeaderboard(convertedScore, activeScene.name);
        if (levelManager.passedTime < PlayerPrefs.GetFloat(activeScene.name) || PlayerPrefs.GetFloat(activeScene.name) == 0)
        {
            PlayerPrefs.SetFloat(activeScene.name, levelManager.passedTime);
        }
    }

    void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }

    void SendLeaderboard(int score, string leaderboardName)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate {
                    StatisticName = leaderboardName,
                    Value = score * -1
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Sent Leaderboard");
    }
}
