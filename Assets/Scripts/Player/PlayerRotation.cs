using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 400f;
    float rotationDirection;
    public float rotation = -90f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rotation += rotationDirection * rotationSpeed * Time.fixedDeltaTime;
        rb.transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    public void Rotate(int value)
    {
        rotationDirection = value;
    }
}
