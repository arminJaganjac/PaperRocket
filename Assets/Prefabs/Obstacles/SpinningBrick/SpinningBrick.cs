using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBrick : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 50f;
    [SerializeField] float startRotation = 0f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.transform.rotation = Quaternion.Euler(0, 0, startRotation);
    }

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.unscaledDeltaTime);
    }
}
