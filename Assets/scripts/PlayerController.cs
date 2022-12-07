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
    private int slag = 0;

    private void OnMouseDrag()
    {
        if (canDrag && rb.velocity.magnitude <= 0.02f)
        {
            rxcord = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            rycord = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            GlobalVariables.force.x = (dxcord - rxcord);
            GlobalVariables.force.y = (dycord - rycord);
            GlobalVariables.force.x = Mathf.Clamp(GlobalVariables.force.x, -2f, 2f) * forcemult;
            GlobalVariables.force.y = Mathf.Clamp(GlobalVariables.force.y, -2f, 2f) * forcemult;
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
            rb.AddForce(GlobalVariables.force, ForceMode2D.Impulse);
            changewind = true;
            GlobalVariables.Strokes++;
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        winder();
    }
    private void Update()
    {
        if(rb.velocity.magnitude >= 0.02f)
        {
            rb.AddForce(GlobalVariables.wind * Time.deltaTime, ForceMode2D.Force);
        }
        if(changewind == true && rb.velocity.magnitude == 0.0f)
        {
            winder();
        }
    }
    private void winder() 
    {
        changewind = false;
        GlobalVariables.wind.x = UnityEngine.Random.Range(-1000, 1000);
        Debug.Log(GlobalVariables.wind);
    }
}


