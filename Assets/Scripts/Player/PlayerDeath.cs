using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] ParticleSystem crash;

    LevelManager levelManager;
    Rigidbody2D rb;
    PlayerRotation playerRotation;
    [SerializeField] AudioSource audioSource;

    public static bool isDead = false;

    void Awake()
    {
        playerRotation = GetComponentInParent<PlayerRotation>();
        rb = GetComponent<Rigidbody2D>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isDead = true;
        AdManager.isFirstRun = false;
        crash.Play();
        audioSource.Play();
        Time.timeScale = 0f;
        if (AdManager.Instance.timePlayingTimer <= 0)
        {
            AdManager.Instance.ShowAd();
            AdManager.Instance.timePlayingTimer = 300f;
        }
        StartCoroutine(nameof(ResetScene));
    }

    IEnumerator ResetScene()
    {
        yield return new WaitForSecondsRealtime(0.7f);
        levelManager.fuelLevel = 10f;
        levelManager.passedTime = 0;
        levelManager.isTimerStarted = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
