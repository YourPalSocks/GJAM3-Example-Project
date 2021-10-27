using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLevel : MonoBehaviour
{
    public GameManager manager;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            manager.WinLevel();
        }
    }
}
