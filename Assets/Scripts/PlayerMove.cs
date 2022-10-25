using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private bool isMoving = false;
    private Vector3 targetPosition = new Vector3();
    private float speed = 3.5f;

    void Update()
    {
        if (isMoving == true)
        {
            Move();
        }
    }

    GameObject goLine = null;
    GameObject goLine1 = null;
    LineRenderer line = null;

    public void StopGame()
    {
        isMoving = false;
    }

    private void Move()
    {
        //transform.Rotate(0, 0, 0.1f);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (line != null) { line.SetPosition(1, transform.position); }

        if (transform.position == targetPosition)
        {
            isMoving = false;

            if (gameObject.GetComponent<PlayerClick>().Lline.Count > 1)
            {
                goLine1 = gameObject.GetComponent<PlayerClick>().Lline[1];
                line = goLine1.GetComponent<LineRenderer>();
            }

            goLine = gameObject.GetComponent<PlayerClick>().Lline[0];
            Destroy(goLine, 0.1f);

            gameObject.GetComponent<PlayerClick>().Lline.RemoveAt(0);
            gameObject.GetComponent<PlayerClick>().Lway.RemoveAt(0);

            if (gameObject.GetComponent<PlayerClick>().Lway.Count > 0)
            {
                SetTargetPosition();
            }
            else
            {
                gameObject.GetComponent<PlayerClick>().Start();
            }

        }
    }

    public void SetTargetPosition()
    { 
        targetPosition = gameObject.GetComponent<PlayerClick>().Lway[0];

        isMoving = true;
    }
}
