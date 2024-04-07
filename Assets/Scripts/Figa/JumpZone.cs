using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class JumpZone : MonoBehaviour
{
    public Transform startPosition; // Starting position
    public Transform endPosition; // Target position
    public float duration = 5f; // Duration of the movement from start to end in seconds
    public GameObject player;
    public GameObject toKill;
    private GameObject hitter;

    private bool inRange = false;
    private float elapsedTime = 0f; // Time elapsed since the start of the movement
    private bool isMoving = false; // Flag to control when the movement starts
    public bool canJump = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        hitter = GameObject.FindGameObjectWithTag("Hiter");
    }

    void Update()
    {
        
            // Start moving when the player presses the space key
            if (inRange && canJump)
            {
                if (Input.GetKeyDown(KeyCode.F) && !isMoving)
                {
                    isMoving = true;
                    elapsedTime = 0f; // Reset elapsed time
                }
            }

            // Handle the movement
            if (isMoving)
            {
                MoveObject();
            }
    }

    void MoveObject()
    {
        // Increment the elapsed time
        elapsedTime += Time.deltaTime;

        // Calculate the current position based on the elapsed time
        Vector3 currentPosition = Vector3.Lerp(startPosition.position, endPosition.position, elapsedTime / duration);

        // Move the GameObject to the current position
        player.transform.position = currentPosition;

        // Check if the movement is complete
        if (elapsedTime >= duration)
        {
            isMoving = false; // Stop the movement
            player.transform.position = endPosition.position; // Ensure the GameObject is exactly at the end position
            Destroy(toKill);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
