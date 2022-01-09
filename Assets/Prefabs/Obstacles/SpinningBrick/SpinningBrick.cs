using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBrick : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 50f;
    
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
