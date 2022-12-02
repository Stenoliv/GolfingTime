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

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    private void Update()
    {
        if (rb2D.velocity.magnitude < 0.15)
        {
            rb2D.velocity = new Vector2(0,0);
        }
        Debug.Log(rb2D.velocity.magnitude);
        Debug.Log("Stopped " + map(rb2D.velocity.magnitude, 10f, 1f, 0f, 0f));
    }
}
