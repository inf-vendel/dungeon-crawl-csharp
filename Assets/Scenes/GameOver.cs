using System.Collections;
using System.Collections.Generic;
using Assets.Source.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public void Update()
    {
        Battle.Message("You Died");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainMenu");
        }
        
    }

}