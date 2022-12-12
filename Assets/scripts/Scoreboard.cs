using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public Text scoreboard;


    private void Start()
    {
        scoreboard = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreboard.text = "Course Over \n\nLevel1 - Par: 3 / Your score: " + GlobalVariables.Level1 + "\n\nLevel2 - Par: 3 / Your score: " + (GlobalVariables.Score - GlobalVariables.Level1) + "\n\nLevel3 - Par: 3 / Your score: " + GlobalVariables.Level2 + "\n\nTotal Score: " + GlobalVariables.Score;
    }
}
