using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class golfHole : MonoBehaviour
{
    public GameObject GameEndHUD;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check what level
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            GlobalVariables.Level1 = GlobalVariables.Strokes;
            GlobalVariables.Score = GlobalVariables.Strokes;
            GlobalVariables.Strokes = 0;
        } else if (SceneManager.GetActiveScene().name == "Level2")
        {
            GlobalVariables.Level2 = GlobalVariables.Strokes;
            GlobalVariables.Score = GlobalVariables.Strokes + GlobalVariables.Score;
            GlobalVariables.Strokes = 0;
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            GlobalVariables.Level3 = GlobalVariables.Strokes;
            GlobalVariables.Score = GlobalVariables.Strokes + GlobalVariables.Score;
            GlobalVariables.Strokes = 0;

        }
        else
        {
            GlobalVariables.Score = GlobalVariables.Strokes + GlobalVariables.Score;
            GlobalVariables.Strokes = 0;
        }

        GameEndHUD.SetActive(true);    
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
