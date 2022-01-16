using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScreen : MonoBehaviour
{
    [SerializeField] GameObject scoreScreen;
    [SerializeField] public TMP_Text congratulationText;
    [SerializeField] TMP_Text lastScoreText;

    List<string> randomScoreText = new List<string> { "You did so well!", "Great result!", "Awesome!", "Wow!", "Very nice!", "Sooo good!" };

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
}
