using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sand : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D playerRB;
    private bool playerTouchingMe = false;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            Debug.Log("Player On Sand!!");
            playerTouchingMe = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            Debug.Log("Player Left Sand!!");
            playerTouchingMe = false;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerTouchingMe == true)
        {
            Vector2 slow = new Vector2(0, 0);
            slow.x = (playerRB.velocity.x * -1) * 2;
            Debug.Log(playerRB.velocity + "/" + slow);
            playerRB.AddForce(slow, ForceMode2D.Impulse);
        }
    }
}
