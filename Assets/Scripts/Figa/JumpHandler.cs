using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpHandler : MonoBehaviour
{
    public float UpmoveSpeed = 5f; // Customizable speed of movement\
    public float diagonalSpeed = 5f;
    private float moveSpeed;

    private Vector3 upDirection = new Vector3(0f, 3.5f, 0f); // Up direction vector
    private Vector3 leftDirection = new Vector3(-7f, 3.5f, 0f); // Left direction vector
    private Vector3 rightDirection = new Vector3(7f, 3.5f, 0f); // Right direction vector

    private Vector3 targetPosition; // The target position to move to
    public bool canJump;
    private bool inRange;
    private void Start()
    {
        targetPosition = transform.position; // Initialize target position to the current position
    }

    private void Update()
    {
        // Check for input and set target position accordingly
        if (inRange && canJump)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                targetPosition = transform.position + upDirection;
                moveSpeed = UpmoveSpeed;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                targetPosition = transform.position + leftDirection;
                moveSpeed = diagonalSpeed;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                targetPosition = transform.position + rightDirection;
                moveSpeed = diagonalSpeed;
            }
        }

        // Move towards the target position at the specified speed
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Platform"))
            {
                inRange = true;
            }
        }

    private void OnTriggerExit(Collider other)
    {
            if (other.gameObject.CompareTag("Platform"))
        {
            inRange = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("DeadZone"))
        {
            ReloadLevel();
        }
    }

    void ReloadLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
