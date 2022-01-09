using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAcceleration : MonoBehaviour
{
    [SerializeField] float moveSpeedMultiplier = 10f;
    float moveSpeed;

    Rigidbody2D rb;
    GameObject flame;
    ParticleSystem flameParticleSystem;
    AudioSource audiox;
    LevelManager levelManager;

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        rb = GetComponent<Rigidbody2D>();
        audiox = GetComponent<AudioSource>();
    }

    void Start()
    {
        flame = GameObject.Find("Flame");
        flameParticleSystem = flame.GetComponent<ParticleSystem>();
    }

    void FixedUpdate()
    {
        Accelerate();
    }

    public void AccelerateButton(int value)
    {
        moveSpeed = value;
    }

    void Accelerate()
    {
        if (moveSpeed != 0 && !levelManager.isFuelEmpty)
        {
            rb.AddForce(transform.up * moveSpeed * moveSpeedMultiplier * Time.fixedDeltaTime);
            audiox.mute = false;
            flameParticleSystem.Play();
        }
        else
        {
            audiox.mute = true;
            flameParticleSystem.Stop();
        }

        if (moveSpeed != 0)
        {
            levelManager.UseFuel();
        }
    }
}