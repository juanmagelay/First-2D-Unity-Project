using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 10f;

    public void Move(float input)
    {
        transform.position += transform.up * input * speed * Time.deltaTime;
    }

    public void Rotate(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            transform.up = direction;
        }
    }
}

