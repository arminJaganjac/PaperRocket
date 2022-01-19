using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float blackHoleMass = 100f;

    float gravityStrength;
    Vector2 blackHolePosition;
    Rigidbody2D rb;


    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        blackHolePosition = transform.position;
    }

    void Update()
    {
        gravityStrength = blackHoleMass / Mathf.Pow(GravityDistance().magnitude, 2);
    }

    void FixedUpdate()
    {
        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.fixedUnscaledDeltaTime);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        rb.AddForce(GravityDirection() * gravityStrength);
    }

    Vector2 GravityDistance()
    {
        Vector2 gravityDistance = blackHolePosition - rb.position;
        return gravityDistance;
    }

    Vector2 GravityDirection()
    {
        return GravityDistance().normalized;
    }
}
