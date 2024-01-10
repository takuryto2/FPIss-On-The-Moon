using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float GroundDrag;

    public Transform PlayerObj;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Vector3 currentSpeed;

    public float playerHeight;
    public LayerMask whatIsGrounded;
    bool isGrounded;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.1f, whatIsGrounded);
        MyInput();
        GroundCheck();
        SpeedControl();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = PlayerObj.forward * verticalInput + PlayerObj.right * horizontalInput;

        currentSpeed = moveDirection.normalized * moveSpeed * 10f;

        rb.AddForce(currentSpeed, ForceMode.Force);
    }

    private void GroundCheck()
    {
        if (isGrounded)
            rb.drag = GroundDrag;
        else 
            rb.drag = 0;
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel =flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x,rb.velocity.y, limitedVel.z);
        }
    }
}
