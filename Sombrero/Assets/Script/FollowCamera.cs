using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public GameObject player;
    public float cameraSpeed = 2;
    private float offset;

    void Start()
    {
        offset = transform.position.y - player.transform.position.y;
    }

    void FixedUpdate()
    {        
        transform.position = new Vector3(transform.position.x, player.transform.position.y + offset, transform.position.z);
    }
}
