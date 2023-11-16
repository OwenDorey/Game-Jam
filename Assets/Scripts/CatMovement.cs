using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float horizontal;
    private bool isFacingRight = true;

    public float speed = 5f;
    public float jumpPower = 10f;
    public float coyoteTime = 0.2f;
    [SerializeField] private float coyoteTimeCounter;

    public Animator animator;
    private void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        
        if (rb.velocity.x != 0 && IsGrounded())
        {
            animator.SetBool("IsMoving", true);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsJumping", false);
        }
        else if (rb.velocity.x == 0 && IsGrounded())
        {
            animator.SetBool("IsIdle", true);
            animator.SetBool("IsMoving", false);
            animator.SetBool("IsJumping", false);
        }
        else if (!IsGrounded())
        {
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsMoving", false);
            animator.SetBool("IsIdle", false);
        }

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }

        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && coyoteTimeCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            coyoteTimeCounter = 0f;
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    // Flip cat direction
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}