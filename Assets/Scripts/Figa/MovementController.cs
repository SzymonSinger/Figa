using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
   [Header("Basic values")]
   [Tooltip("Speed of Figa movement")]
   public float speed = 5.0f;
   [Tooltip("Force of the Figa Jump")]
   public float jumpForce = 7.0f;

   private Rigidbody rb;
   private bool isGrounded;

   private void Start()
   {
      rb = GetComponent<Rigidbody>();
   }

   private void Update()
   {
      float moveHorizontal = Input.GetAxis("Horizontal") * speed;
      Vector3 movement = new Vector3(moveHorizontal, rb.velocity.y, 0.0f);
      rb.velocity = movement;

      if (Input.GetButtonDown("Jump") && isGrounded)
      {
         rb.AddForce(new Vector3(0.0f, jumpForce, 0.0f), ForceMode.Impulse);
         isGrounded = false;
      }
   }

   private void OnCollisionEnter(Collision collision)
   {
      if (collision.contacts[0].normal.y > 0.5f)
      {
         isGrounded = true;
      }
   }
}
