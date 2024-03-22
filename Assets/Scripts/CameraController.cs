using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject.
    private Vector3 offset; // Offset between the camera and the player. Offset is the difference between the camera's position and the player's position.
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; // Calculate the initial offset.
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; // Update the camera's position to be the player's position plus the offset.
    }
}
