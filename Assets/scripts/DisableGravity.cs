using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGravity : MonoBehaviour
{
    Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    float Remap(float source, float sourceFrom, float sourceTo, float targetFrom, float targetTo)
    {
        return targetFrom + (source - sourceFrom) * (targetTo - targetFrom) / (sourceTo - sourceFrom);
    }

    private void FixedUpdate()
    {
        float Multiply = Remap(rb2D.velocity.magnitude, 0.00001f, 0.15f, 0f, 1f);
        if (rb2D.velocity.magnitude < 0.15f)
        {
            rb2D.velocity = rb2D.velocity * Multiply;
        }
    }
}
