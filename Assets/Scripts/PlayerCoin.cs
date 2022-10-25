using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoin : MonoBehaviour
{
    GUIStyle style = new GUIStyle();
    int counter = 0;
    private string stext = "";

    void Start()
    {
        style.normal.textColor = Color.yellow;
        style.fontSize = 32;
        style.fontStyle = FontStyle.Bold;
        stext = "Coins: " + counter;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 34), stext, style);
    }

    public void GetCoin()
    {
        counter++;
        stext = "Coins: " + counter;
    }

    public void StopGame(int i)
    {
        if (i == -1)
        {
            style.normal.textColor = Color.red;
            stext = "FAIL";
        }

        if (i == 1)
        {
            style.normal.textColor = Color.green;
            stext = "WIN";
        }
    }
}
