using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] ParticleSystem crash;

    LevelManager levelManager;
    Rigidbody2D rb;
    PlayerRotation playerRotation;

    public static bool isDead;

    void Awake()
    {
        playerRotation = GetComponentInParent<PlayerRotation>();
        rb = GetComponent<Rigidbody2D>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isDead = true;
        crash.Play();
        if (AdManager.Instance.timePlayingTimer <= 0)
        {
            AdManager.Instance.ShowAd();
            AdManager.Instance.timePlayingTimer = 300f;
        }
        levelManager.fuelLevel = 10f;
        levelManager.passedTime = 0;
        levelManager.isTimerStarted = false;
        PlayerVelocityZero();
        Invoke(nameof(ResetPlayerPosition), 0.8f);
    }

    void ResetPlayerPosition()
    {
        PlayerVelocityZero();
        rb.transform.position = new Vector3(0, 0, 0);
        playerRotation.rotation = -90;
        isDead = false;
    }

    void PlayerVelocityZero()
    {
        rb.velocity = new Vector2(0, 0);
        rb.angularVelocity = 0;
    }
}
