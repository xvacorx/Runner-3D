using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float jumpForce = 7.5f;
    private bool isGrounded;
    [SerializeField] private Rigidbody rb;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked; // Toggle Cursor - OFF
    }
    void Update()
    {
        {
            isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.5f);

            float horizontalMovement = Input.GetAxis("Horizontal");
            horizontalMovement *= Time.deltaTime;

            Vector3 movement = new Vector3(horizontalMovement, 0, 0) * 100f * movementSpeed * Time.deltaTime;
            rb.MovePosition(transform.position + movement);

            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        } // Movement
    }
}