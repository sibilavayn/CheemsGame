using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneExit : LevelLoader
{
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        {   
            LoadNextLevel();
        }
    }
}
