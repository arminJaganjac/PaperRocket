using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using PlayFab;

public class ScoreScreen : MonoBehaviour
{
    [SerializeField] GameObject scoreScreen;
    [SerializeField] public TMP_Text congratulationText;
    [SerializeField] TMP_Text lastScoreText;
    [SerializeField] GameObject rowPrefab;
    [SerializeField] Transform rowsParent;
    [SerializeField] GameObject personalBestRow;

    List<string> randomScoreText = new List<string> { "You did so well!", "Great result!", "Awesome!", "Wow!", "Very nice!", "Sooo good!" };

    [SerializeField] LevelExit levelExit;
    [SerializeField] LevelManager levelManager;

    [SerializeField] List<AudioClip> cheers = new List<AudioClip>();

    AudioSource audioSource;
    MusicManager musicManager;

    void Awake()
    {
        musicManager = FindObjectOfType<MusicManager>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = cheers[Random.Range(0, cheers.Count)];
        audioSource.Play();
    }

    void Start()
    {
        musicManager.PlayNextClip();
        RequestLeaderboards();
    }

    public void EnableScoreScreen()
    {
        scoreScreen.SetActive(true);
    }

    public void SetLastScoreText(float lastScore)
    {
        string lastScoreString = lastScore.ToString("F2");
        lastScoreText.SetText("Last Score:\n" + lastScoreString);
    }

    public void SetCongratulationText()
    {
        if (levelManager.passedTime < PlayerPrefs.GetFloat(levelExit.activeScene.name) || PlayerPrefs.GetFloat(levelExit.activeScene.name, 0) == 0)
        {
            congratulationText.SetText("New Personal Record!");
        }
        else
        {
            congratulationText.SetText(randomScoreText[Random.Range(0, randomScoreText.Count)]);
        }
    }

    void RequestLeaderboards()
    {
        StartCoroutine(nameof(GetLeaderboard));
        StartCoroutine(nameof(GetLeaderboardAroundPlayer));
    }

    IEnumerator GetLeaderboard()
    {
        yield return new WaitForSecondsRealtime(2f);
        var request = new GetLeaderboardRequest
        {
            StatisticName = SceneManager.GetActiveScene().name,
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        Debug.Log("Received leaderboard update");

        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            TMP_Text[] texts = newGo.GetComponentsInChildren<TMP_Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = (item.StatValue / -100f).ToString("F2");
        }
    }

    void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }

    IEnumerator GetLeaderboardAroundPlayer()
    {
        yield return new WaitForSecondsRealtime(2f);
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = SceneManager.GetActiveScene().name,
            MaxResultsCount = 1
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderboardAroundPlayerGet, OnError);
    }

    void OnLeaderboardAroundPlayerGet(GetLeaderboardAroundPlayerResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            TMP_Text[] pbTexts = personalBestRow.GetComponentsInChildren<TMP_Text>();
            pbTexts[0].text = (item.Position + 1).ToString();
            pbTexts[1].text = PlayerPrefs.GetString("Username");
            pbTexts[2].text = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name).ToString("F2");
        }
    }
}
