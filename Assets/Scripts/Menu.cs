using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    GUIStyle style = new GUIStyle();
    private string sResult = "";

    private int CC0 = 5;
    private int CS0 = 5;

    private int CC1 = 10;
    private int CS1 = 10;

    private void Start()
    {
        
        style.fontSize = 32;
        style.fontStyle = FontStyle.Bold;

        if (Data.result == -1)
        {
            //Debug.Log("FAIL");
            style.normal.textColor = Color.red;
            sResult = "FAIL";
            Data.CC = CC0;
            Data.CS = CS0;
        }

        if (Data.result == 1)
        {
            //Debug.Log("WIN");
            style.normal.textColor = Color.green;
            sResult = "WIN";
            if (Data.CC + 1 < CC1) { Data.CC++; }
            if (Data.CS + 1 < CS1) { Data.CS++; }
        }

    }

    public void ButtonClick()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 34), sResult, style);
    }

}
