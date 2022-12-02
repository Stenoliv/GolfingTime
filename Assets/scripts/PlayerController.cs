using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CircleCollider2D ballCollision;
    private bool canDrag = false;
    
    void OnMouseDown()
    {
        canDrag = true;
    }
    private void OnMouseUp()
    {
        canDrag = false;
    }

    private void OnMouseDrag()
    {
        if (canDrag) Debug.Log("Its okay");
    }
}
