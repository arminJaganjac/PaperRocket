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
    LevelManager levelManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void FixedUpdate()
    {
        rotation += rotationDirection * rotationSpeed * Time.fixedDeltaTime;
        rb.transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    // takes touchscreen input
    public void Rotate(int value)
    {
        rotationDirection = value;
    }

    public void RotateLeft(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            levelManager.StartTime();
            rotationDirection = 1;
        }
        if (context.canceled)
        {
            rotationDirection = 0;
        }
    }

    public void RotateRight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            levelManager.StartTime();
            rotationDirection = -1;
        }
        if (context.canceled)
        {
            rotationDirection = 0;
        }
    }
}
