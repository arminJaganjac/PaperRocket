using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] TMP_Text tutorialText;
    [SerializeField] GameObject fuelSlider;
    [SerializeField] Image accelerateButton;
    [SerializeField] GameObject score;
    [SerializeField] GameObject tutorialImage;
    [SerializeField] GameObject continueText;

    string[] tutorialTextArray = new string[5];
    int tutorialStepCounter = 0;
    int rotationButtonCounter = 0;

    LevelManager levelManager;

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Start()
    {
        tutorialTextArray[0] = "Press the \"Left\" and \"Right\" buttons to rotate the rocket.";
        tutorialTextArray[1] = "Well done! Watch the fuel level so you don't run out of fuel!";
        tutorialTextArray[2] = "Try to get to the level exit as fast as you can.";
        tutorialTextArray[3] = "Press the \"Accelerate\" button to accelerate the rocket.";
        tutorialTextArray[4] = "Tip: If you want to brake you have to turn around and accelerate.";
    }

    void Update()
    {
        ChangeTutorialText();
    }

    public void IncreaseRotationButtonCounter()
    {
        rotationButtonCounter++;

        if (rotationButtonCounter == 2)
        {
            tutorialStepCounter++;
        }
    }

    public void IncreaseTutorialStepCounter()
    {
        tutorialStepCounter++;
    }

    void ChangeTutorialText()
    {
        switch (tutorialStepCounter)
        {
            case 0:
                tutorialText.SetText(tutorialTextArray[0]);
                Debug.Log("Case 0");
                break;
            case 1:
                tutorialText.SetText(tutorialTextArray[1]);
                Debug.Log("Case 1");
                fuelSlider.SetActive(true);
                continueText.SetActive(true);
                break;
            case 2:
                tutorialText.SetText(tutorialTextArray[2]);
                Debug.Log("Case 2");
                levelManager.passedTime = 0f;
                score.SetActive(true);
                break;
            case 3:
                tutorialText.SetText(tutorialTextArray[3]);
                Debug.Log("Case 3");
                continueText.SetActive(false);
                accelerateButton.enabled = true;
                break;
            case 4:
                tutorialText.SetText(tutorialTextArray[4]);
                Debug.Log("Case 4");
                break;
            default:
                Debug.Log("Case default");
                tutorialImage.SetActive(false);
                break;
        }
    }
}