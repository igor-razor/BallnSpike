using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float _rot_speed = 1.0f;

    void Start()
    {
        _rot_speed = Random.Range(0.5f, 1.5f);
    }

    void Update()
    {
        transform.Rotate(0, 0, _rot_speed);
    }
}
