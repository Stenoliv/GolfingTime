using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CircleCollider2D ballCollision;
    private bool canDrag = false;
    private float dxcord;
    private float dycord;
    private float rxcord;
    private float rycord;
    bool changewind = false;
    private Rigidbody2D rb;
    public float forcemult = 3;
    Vector2 force = new Vector2();
    Vector2 wind = new Vector2();

    private void OnMouseDrag()
    {
        if (canDrag && rb.velocity.magnitude <= 0.02f)
        {
            rxcord = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            rycord = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            force.x = (dxcord - rxcord);
            force.y = (dycord - rycord);

        }
    }
    void OnMouseDown()
    {
        canDrag = true;
        if (Input.GetMouseButtonDown(0) == true)
        {
            dxcord = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            dycord = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        }
    }
    private void OnMouseUp()
    {
        canDrag = false;
        if (Input.GetMouseButtonUp(0) == true && rb.velocity.magnitude <= 0.02f)
        {
            force.x = Mathf.Clamp(force.x, -2f,2f);
            force.y = Mathf.Clamp(force.y, -2f, 2f);
            rb.AddForce(force * forcemult, ForceMode2D.Impulse);
            changewind = true;
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        winder();
    }
    private void Update()
    {
        if(rb.velocity.magnitude >= 0.8f)
        {
            rb.AddForce(wind, ForceMode2D.Force);
        }
        if(changewind == true)
        {
            winder();
        }
    }
    private void winder() 
    {
        changewind = false;
        wind.x = UnityEngine.Random.Range(-0.5f, 0.5f);
        Debug.Log(wind);
    }
}


