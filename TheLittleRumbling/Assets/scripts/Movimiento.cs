using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 12f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public float moveInput;
    public Collider2D isGrounded;


    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(
        groundCheck.position,
        groundCheckRadius,
       groundLayer

       );

        if (Input.GetKeyDown(KeyCode.Space) &&
       isGrounded)
        {
            rb.linearVelocity = new
           Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (spriteRenderer != null)
     {
            if (moveInput > 0) spriteRenderer.flipX = false;
            else if (moveInput < 0) spriteRenderer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (animator != null) animator.SetTrigger("Attack");
        }
        if (animator != null)
        {
            animator.SetFloat("Speed", Mathf.Abs(moveInput));
            animator.SetBool("Grounded", isGrounded);
            animator.SetFloat("VerticalSpeed", rb.linearVelocity.y);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed,rb.linearVelocity.y);
    }
}