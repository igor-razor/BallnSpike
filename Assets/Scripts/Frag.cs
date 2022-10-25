using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frag : MonoBehaviour
{
    private Vector3 target = new Vector3();

    private float speed = 5f;

    private float range1 = -1.0f;
    private float range2 = 1.0f;

    void Start()
    {
        target.x = Random.Range(transform.position.x + range1, transform.position.x + range2);
        target.y = Random.Range(transform.position.y + range1, transform.position.y + range2);
        target.z = Random.Range(transform.position.z + range1, transform.position.z + range2);

    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
