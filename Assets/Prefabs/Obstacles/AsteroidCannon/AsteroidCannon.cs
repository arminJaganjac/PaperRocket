using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCannon : MonoBehaviour
{
    [SerializeField] GameObject asteroid;

    Vector3 asteroidPosition;

    void Start()
    {
        asteroidPosition = transform.position + transform.up * 1.5f;
    }

    void SingleShot()
    {
        Instantiate(asteroid, asteroidPosition, transform.rotation);
    }
}
