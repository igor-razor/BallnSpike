using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGen : MonoBehaviour
{
    //private int count_coins = 5;
    //private int count_spikes = 5;

    private int countW = 16;
    private int countH = 9;

    private float Z = 1;

    private List<Vector2> LRndPos = new List<Vector2>();

    private Vector3 v3 = new Vector3();
    private Vector2 v2 = new Vector2();

    void Start()
    {
        //GenCorners();

        GenPlane();
        GenRandomPositions(countW, countH);
        GenPlayer();
        GenCoins(Data.CC);
        GenSpikes(Data.CS);
        
    }

    private void GenPlane()
    {
        GameObject goUnit = GameObject.CreatePrimitive(PrimitiveType.Plane);
        goUnit.name = "Plane";
        goUnit.GetComponent<Renderer>().material.color = Color.HSVToRGB(217,60,47,true);

        goUnit.transform.eulerAngles = new Vector3(90, 0, 180);
        goUnit.transform.localScale = new Vector3(2, 1, 1);
        goUnit.transform.position = new Vector3(8, 4.5f, 1.5f);
    }

    private void GenRandomPositions(int W, int H)
    {
        for (int i = 0; i < countW; i++)
            for (int j = 0; j < countH; j++)
            {
                v2.x = i;
                v2.y = j;
                LRndPos.Add(v2);
            }
    }

    private void GenPlayer()
    {
        GameObject goUnit = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        goUnit.name = "Player";
        goUnit.GetComponent<Renderer>().material.color = Color.gray;

        goUnit.AddComponent<PlayerClick>();
        goUnit.AddComponent<PlayerMove>();
        goUnit.AddComponent<PlayerGet>().tec_coins = Data.CC;
        goUnit.AddComponent<PlayerCoin>();

        goUnit.GetComponent<SphereCollider>().isTrigger = true;

        goUnit.AddComponent<Rigidbody>().useGravity = false;
        goUnit.GetComponent<Rigidbody>().isKinematic = true;

        goUnit.transform.position = GetRndPos();        

    }

    private Vector3 rotCoin = new Vector3(90, 0, 0);
    private Vector3 scaleCoin = new Vector3(1, 0.1f, 1);

    private void GenCoins(int n)
    {
        for (int i = 0; i < n; i++)
        {
            GameObject goUnit = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            goUnit.name = "Coin";
            goUnit.GetComponent<Renderer>().material.color = Color.yellow;

            goUnit.transform.localEulerAngles = rotCoin;
            goUnit.transform.localScale = scaleCoin;
            
            goUnit.transform.position = GetRndPos();

            goUnit.AddComponent<Rotation>();
        }
    }

    private void GenSpikes(int n)
    {
        for (int i = 0; i < n; i++)
        {
            GameObject goUnit = GameObject.CreatePrimitive(PrimitiveType.Cube);
            goUnit.name = "Spike";
            goUnit.GetComponent<Renderer>().material.color = Color.red;
            goUnit.transform.position = GetRndPos();

            goUnit.AddComponent<Rotation>();
        }
    }

    private Vector3 GetRndPos()
    {
        int i = Random.Range(0, LRndPos.Count);
        v3.x = LRndPos[i].x;
        v3.y = LRndPos[i].y;
        v3.z = Z;
        LRndPos.RemoveAt(i);

        float xx = v3.x;
        float yy = v3.y;

        if ((xx - 1 >= 0) && (yy + 1 < countH)) { v2.x = xx - 1; v2.y = yy + 1; LRndPos.Remove(v2); }
        if ((xx + 1 < countW) && (yy - 1 >= 0)) { v2.x = xx + 1; v2.y = yy - 1; LRndPos.Remove(v2); }
        if ((xx - 1 >= 0) && (yy - 1 >= 0)) { v2.x = xx - 1; v2.y = yy - 1; LRndPos.Remove(v2); }
        if ((xx + 1 < countW) && (yy + 1 < countH)) { v2.x = xx + 1; v2.y = yy + 1; LRndPos.Remove(v2); }

        if (xx + 1 < countW) { v2.x = xx + 1; v2.y = yy; LRndPos.Remove(v2); }
        if (xx - 1 >= 0) { v2.x = xx - 1; v2.y = yy; LRndPos.Remove(v2); }
        if (yy - 1 >= 0) { v2.x = xx; v2.y = yy - 1; LRndPos.Remove(v2); }
        if (yy + 1 < countH) { v2.x = xx; v2.y = yy + 1; LRndPos.Remove(v2); }

        return v3;
    }

    private void GenCorners()
    {
        GameObject goUnit1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        goUnit1.transform.position = new Vector3(0, 0);
        GameObject goUnit2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        goUnit2.transform.position = new Vector3(countW, 0);
        GameObject goUnit3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        goUnit3.transform.position = new Vector3(0, countH);
        GameObject goUnit4 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        goUnit4.transform.position = new Vector3(countW, countH);
    }
}
