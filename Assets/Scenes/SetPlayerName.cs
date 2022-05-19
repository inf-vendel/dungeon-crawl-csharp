using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerName : MonoBehaviour
{
    public static string PlayerName="Anonymous";


    public void ReadStringInput(string s)
    {
        PlayerName = s;
    }
}
