using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float turnRate = 7f;
    [SerializeField] private Camera mainCamera; // Reference to the camera

    private void Update()
    {
        Vector2 inputVector = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x += 1;
        }

        inputVector = inputVector.normalized;

        // Get the forward and right directions relative to the camera
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        // Flatten the camera directions on the XZ plane
        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate movement direction based on camera orientation
        Vector3 moveDir = (cameraForward * inputVector.y + cameraRight * inputVector.x).normalized;

        // Rotate the player to face the movement direction
        if (moveDir != Vector3.zero)
        {
            transform.LookAt(transform.position + Vector3.Slerp(transform.forward.normalized, moveDir, Time.deltaTime * turnRate));
        }

        // Move the player
        transform.position += moveDir * Time.deltaTime * moveSpeed;
    }
}
