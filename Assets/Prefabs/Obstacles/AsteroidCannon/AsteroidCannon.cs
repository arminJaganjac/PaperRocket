using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCannon : MonoBehaviour
{
    [SerializeField] GameObject asteroid;
    [SerializeField] float firstShotDelay = 0f;

    Vector3 asteroidPosition;


    // Set time between SingleShots in Animation


    void Start()
    {
        StartCoroutine("SingleShot");
        asteroidPosition = transform.position + transform.up * 1.5f;
    }

    IEnumerator SingleShot()
    {
        yield return new WaitForSeconds(firstShotDelay);
        Instantiate(asteroid, asteroidPosition, transform.rotation);
    }
}
