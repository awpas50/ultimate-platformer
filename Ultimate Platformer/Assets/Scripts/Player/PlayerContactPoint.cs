using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContactPoint : MonoBehaviour
{
    public bool isCollided = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag != "Player")
        {
            isCollided = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag != "Player")
        {
            isCollided = false;
        }
    }
}
