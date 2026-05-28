using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class Menu : CSoundManager
{
    GUIStyle style = new GUIStyle();
    private string sResult = "";

    private int CC0 = 5;
    private int CS0 = 5;

    private int CC1 = 10;
    private int CS1 = 10;

    private void Start()
    {
        FLoadMusic();
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
        PlaySound(CS.MainAudio[(int)CS.M.a09musicmenu], 0.75f, true, 1.0f, CS.MainAudio[(int)CS.M.a01gameover].length + 0.1f);
    }

    public void ButtonClick()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 34), sResult, style);
    }

    private void FLoadMusic()
    {
        //Debug.Log("load music");

        CS.MainAudio = Resources.LoadAll<AudioClip>("Sounds/Pack1");

        string main_dir_path = Application.dataPath + "/Resources/Sounds";

        //Debug.Log(main_dir_path);

        //List<string> Ldir = new List<string>();
        //int count = 0;

        if (Directory.Exists(main_dir_path))
        {
            DirectoryInfo mainDir = new DirectoryInfo(main_dir_path);
            DirectoryInfo[] subDirs = mainDir.GetDirectories();

            int count = Directory.GetDirectories(main_dir_path).Length;
            //Debug.Log(count);

            CS.MPackPath = new string[count];

            //foreach (DirectoryInfo subD in subDirs) { Debug.Log(subD.Name); }

            for (int i = 0; i < count; i++)
            {
                CS.MPackPath[i] = subDirs[i].Name;
                //FcreateMusicBot(subDirs[i].Name);
            }
        }
    }
}
