using System.Collections;
using System.Collections.Generic;
using Assets.Source.Core;
using DungeonCrawl;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public void Update()
    {
        // Utilities.Message("You Died", UserInterface.TextPosition.BottomCenter);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainMenu");
        }
        
    }

}