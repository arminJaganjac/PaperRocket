using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCannon : MonoBehaviour
{
    [SerializeField] GameObject asteroid;
    [SerializeField] float firstShotDelay = 0f;

    Vector3 asteroidPosition;

    void Start()
    {
        StartCoroutine(SingleShot(firstShotDelay));
        asteroidPosition = transform.position + transform.up * 1.5f;
    }

    IEnumerator SingleShot(float firstShotDelay)
    {
        yield return new WaitForSeconds(firstShotDelay);
        Instantiate(asteroid, asteroidPosition, transform.rotation);
    }
}
