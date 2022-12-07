using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerHUD;
    public TMP_Text wind;
    public TMP_Text totalStrokes;
    public TMP_Text strokes;
    public TMP_Text angle;
    public TMP_Text force;
    public Image arrow;

    // Update is called once per frame
    void Update()
    {
        wind.text = "Vind: " + Mathf.Round(GlobalVariables.wind.x * 10) / 1000f + " m/s";
        if (GlobalVariables.wind.x >= 0)
        {
            arrow.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        } else arrow.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 180);
        totalStrokes.text = "Slag Totalt: " + (GlobalVariables.Score + GlobalVariables.Strokes);
        strokes.text = "Slag: " + GlobalVariables.Strokes;
        if (GlobalVariables.force.magnitude > 0.001)
        {
            angle.text = "Vinkel: " + Math.Floor(Math.Atan(GlobalVariables.force.y / GlobalVariables.force.x) * Mathf.Rad2Deg) + "°";
        }
        else angle.text = "Vinkel: 0°";
        
        force.text = "Kraft: " + Math.Floor(GlobalVariables.force.magnitude) + "N";
    }
}
