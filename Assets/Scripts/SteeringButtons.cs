using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringButtons : MonoBehaviour
{
    GameObject leftButton;
    GameObject rightButton;
    GameObject accelerateButton;

    void Awake()
    {
        leftButton = transform.GetChild(0).gameObject;
        rightButton = transform.GetChild(1).gameObject;
        accelerateButton = transform.GetChild(2).gameObject;
    }
    void Update()
    {
        if (PlayerDeath.isDead)
        {
            leftButton.SetActive(false);
            rightButton.SetActive(false);
            accelerateButton.SetActive(false);
        }
        else
        {
            leftButton.SetActive(true);
            rightButton.SetActive(true);
            accelerateButton.SetActive(true);
        }
    }
}
