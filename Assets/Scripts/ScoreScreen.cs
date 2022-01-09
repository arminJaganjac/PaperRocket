using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScreen : MonoBehaviour
{
    [SerializeField] GameObject scoreScreen;
    [SerializeField] public TMP_Text congratulationText;
    [SerializeField] TMP_Text lastScoreText;
    [SerializeField] TMP_Text highScoreText;

    List<string> randomScoreText = new List<string> {"You did so well!", "Great result!", "Awesome!", "Wow!", "Very nice!", "Sooo good!"};

    LevelExit levelExit;
    LevelManager levelManager;

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        levelExit = FindObjectOfType<LevelExit>();
    }

    public void EnableScoreScreen()
    {
        scoreScreen.SetActive(true);
    }

    public void SetLastScoreText(int lastScore)
    {
        lastScoreText.SetText("Last Score:\n" + lastScore);
    }

    public void SetHighScoreText()
    {
        highScoreText.SetText("High Score:\n" + PlayerPrefs.GetInt(levelExit.activeScene.name));
    }

    public void SetCongratulationText()
    {
        if (levelManager.score < PlayerPrefs.GetInt(levelExit.activeScene.name) || PlayerPrefs.GetInt(levelExit.activeScene.name) == 0)
        {
            congratulationText.SetText("New High Score!");
        }
        else
        {
            congratulationText.SetText(randomScoreText[Random.Range(0, randomScoreText.Count)]);
        }
    }
}
