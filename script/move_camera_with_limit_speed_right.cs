using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_camera_with_limit_speed_right : MonoBehaviour
{

    public float speedLimit;
    public Movement script;
    void Start()
    {
        script = GameObject.Find("player").GetComponent<Movement>();

    }
    void Update()
    {
        //speedLimit = script.SpeedValues[(int)script.CurrentSpeed];
        //Vector3 moveDirection = new Vector3(1f, 0f, 0f); // Move camera to the right
        //Vector3 newPosition = transform.position + moveDirection * speedLimit * Time.deltaTime;

       // transform.position = newPosition;
    }
}