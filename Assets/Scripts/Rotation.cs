using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : CSoundManager
{
    public float _rot_speed = 1.0f;
    private float rot_del = 10; 
    public GameObject _goPlayer = null;

    void Start()
    {
        _rot_speed = Random.Range(0.5f, 1.5f);
        if (_goPlayer != null) _rot_speed = rot_del / Vector3.Distance(this.gameObject.transform.position, _goPlayer.transform.position);
        if (gameObject.name.Contains("Spike") == true)
        {
            gameObject.AddComponent<AudioSource>();
            PlaySound(CS.MainAudio[(int)CS.M.a07enemyrotate], 0.1f, true, _rot_speed, 0.1f);
        }
    }

    void Update()
    {
        if (_goPlayer != null) _rot_speed = rot_del / Vector3.Distance(this.gameObject.transform.position, _goPlayer.transform.position);
        transform.Rotate(0, 0, _rot_speed);
        if (gameObject.name.Contains("Spike") == true)
        {
            gameObject.GetComponent<AudioSource>().pitch = _rot_speed;
        }
    }
}
