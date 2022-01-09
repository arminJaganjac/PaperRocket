using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] ParticleSystem crash;

    LevelManager levelManager;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        crash.transform.parent = null;
        crash.Play();
        if (AdManager.Instance.timePlayingTimer <= 0)
        {
            AdManager.Instance.ShowAd();
            AdManager.Instance.timePlayingTimer = 300f;
        }
        levelManager.fuelLevel = 10f;
        levelManager.passedTime = 0;
        levelManager.isTimerStarted = false;
        Invoke(nameof(ResetPlayerPosition), 0.8f);
    }

    void ResetPlayerPosition()
    {
        rb.transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector2(0, 0);
        rb.angularVelocity = 0;
        rb.transform.rotation = Quaternion.Euler(0, 0, -90);
    }
}
