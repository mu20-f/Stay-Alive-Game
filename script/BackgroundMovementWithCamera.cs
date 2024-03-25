using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovementWithCamera : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera virtualCamera;
    public float parallaxSpeed = 0.5f; // Adjust this value to control the speed of the parallax effect

    private Vector3 initialCameraPosition;
    public float speedLimit;
    public Movement script;
    void Start()
    {
        script = GameObject.Find("player").GetComponent<Movement>();
        // Store the initial camera position
        if (virtualCamera != null)
        {
            initialCameraPosition = virtualCamera.transform.position;
        }
        else
        {
            Debug.LogError("Virtual camera reference is not set in BackgroundMovement script!");
        }
    }

    void Update()
    {
       // speedLimit = script.SpeedValues[(int)script.CurrentSpeed];
        // Calculate the distance the camera has moved since the start
        float distanceMoved = virtualCamera.transform.position.x - initialCameraPosition.x;

        // Calculate the background's new position based on the parallax effect
        Vector3 newPosition = transform.position + Vector3.right * (distanceMoved * speedLimit);

        // Update the background's position
        transform.position = newPosition;
    }
}
