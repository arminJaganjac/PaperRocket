using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        transform.position += transform.up * moveSpeed * Time.fixedDeltaTime;
        DestroyAsteroid();
    }

    void DestroyAsteroid()
    {
        if (rb.IsTouchingLayers(LayerMask.GetMask("Border")))
        {
            Destroy(gameObject);
        }
    }
}
