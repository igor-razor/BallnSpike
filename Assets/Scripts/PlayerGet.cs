using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGet : CSoundManager
{
    public int tec_coins = 0;
    private float wait_sec = 2.0f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other is BoxCollider)
            if (other.gameObject.name.Contains("Spike") == true)
            {                
                TriggerSpike(other);
            }

        if (other is CapsuleCollider)
            if (other.gameObject.name.Contains("Coin") == true)
            {                
                TriggerCoin(other);
            }
    }

    private void TriggerSpike(Collider other)
    {
        //Debug.Log("Spike");
        Data.result = -1;
        StartCoroutine(WaitLoad());
        GenFrags();
        StopGame();
        gameObject.GetComponent<Renderer>().enabled = false;
        PlaySound(CS.MainAudio[(int)CS.M.a04boomhit], 0.75f, false, 1.0f);
        PlaySound(CS.MainAudio[(int)CS.M.a01gameover], 0.75f, false, 1.0f, CS.MainAudio[(int)CS.M.a04boomhit].length + 0.5f);
    }

    private void TriggerCoin(Collider other)
    {
        //Debug.Log("Coin");
        tec_coins--;
        gameObject.GetComponent<PlayerCoin>().GetCoin();

        Destroy(other.gameObject, 0.1f);

        if (tec_coins == 0)
        {
            //Debug.Log("WIN");
            Data.result = 1;
            PlaySound(CS.MainAudio[(int)CS.M.a06wingame], 0.75f, false, 1.0f);
            StopGame();
            StartCoroutine(WaitLoad());
        }

        PlaySound(CS.MainAudio[(int)CS.M.a05getbonus], 0.75f, false, 1.0f);
        if (gameObject.GetComponent<PlayerMove>().isMoving == true)
        { PlaySound(CS.MainAudio[(int)CS.M.a08playermove], 0.75f, true, 1.0f, CS.MainAudio[(int)CS.M.a05getbonus].length + 0.05f); }
    }

    public void StopGame()
    {
        gameObject.GetComponent<PlayerMove>().StopGame();
        gameObject.GetComponent<PlayerMove>().enabled = false;

        gameObject.GetComponent<PlayerClick>().StopGame();
        gameObject.GetComponent<PlayerClick>().enabled = false;

        gameObject.GetComponent<PlayerCoin>().StopGame(Data.result);

        gameObject.GetComponent<SphereCollider>().enabled = false;
    }

    public IEnumerator WaitLoad()
    {
        yield return new WaitForSeconds(wait_sec);
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }

    private int count_frags = 32;
    private Vector3 s3 = new Vector3(0.3f, 0.3f, 0.3f);

    private void GenFrags()
    {
        for (int i = 0; i < count_frags; i++)
        {
            GameObject goUnit = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            goUnit.name = "Frag";
            goUnit.GetComponent<Renderer>().material.color = Color.gray;
            goUnit.transform.localScale = s3;
            goUnit.transform.position = gameObject.transform.position;
            goUnit.AddComponent<Frag>();          
        }
    }
}
