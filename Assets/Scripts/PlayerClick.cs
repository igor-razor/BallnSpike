using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClick : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    private Vector3 target = new Vector3();

    private Vector3 v0 = new Vector3();
    private Vector3 v3 = new Vector3();


    private float LineW = 0.2f;
    private float Z = 1;

    public List<Vector3> Lway = new List<Vector3>();
    public List<GameObject> Lline = new List<GameObject>();

    private bool start = false;

    public void Start()
    {
        NewMaterial();

        start = false;
        v0 = transform.position;
        Lway.Add(v0);
        DrawLine(v0, v0);
    }

    public void StopGame()
    {
        foreach (GameObject go in Lline)
        {
            Destroy(go);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10000.0f))
            {
                target = hit.point;

                //Debug.Log(target);

                v3.x = target.x;
                v3.y = target.y;
                v3.z = Z;

                Lway.Add(v3);

                DrawLine(Lway[Lway.Count - 1], Lway[Lway.Count - 2]);

                if (start == false)
                {
                    start = true;
                    gameObject.GetComponent<PlayerMove>().SetTargetPosition();
                }
            }            
        }
    }

    private void DrawLine(Vector3 v1, Vector3 v2)
    {
        GameObject line = new GameObject("Line");

        LineRenderer tempLineRenderer = line.AddComponent<LineRenderer>();
        tempLineRenderer.SetPosition(0, v1);
        tempLineRenderer.SetPosition(1, v2);

        tempLineRenderer.material = matLine;
        //tempLineRenderer.startColor = Color.blue;
        //tempLineRenderer.endColor = Color.red;

        tempLineRenderer.startWidth = LineW;
        tempLineRenderer.endWidth = LineW;

        Lline.Add(line);
    }

    private Material matLine;

    private void NewMaterial()
    {
        //matLine = new Material();

        matLine = new Material(Shader.Find("Standard"));
        matLine.SetColor("_Color", new Color(1, 1, 1, .6f));
        matLine.SetFloat("_Mode", 3);
        matLine.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        matLine.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        matLine.EnableKeyword("_ALPHABLEND_ON");
        matLine.renderQueue = 3000;
    }
}
