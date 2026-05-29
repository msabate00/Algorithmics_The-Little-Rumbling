using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 6f;
    public float jumpForce = 12f;

    [Header("Doble Salto")]
    public int maxJumps = 1;

    [Header("Suelo")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Componentes")]
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    // Variables privadas
    private float moveInput;
    private bool isGrounded;
    private int jumpsLeft;

    void Start()
    {
        // Empezar con todos los saltos disponibles
        jumpsLeft = maxJumps;
    }

    void Update()
    {
        // INPUT HORIZONTAL
        moveInput = Input.GetAxisRaw("Horizontal");

        // DETECTAR SUELO
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        // RESET DE SALTOS AL TOCAR EL SUELO
        if (isGrounded)
        {
            jumpsLeft = maxJumps;
        }

        // SALTO Y DOBLE SALTO
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)  && jumpsLeft > 0)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                jumpForce
            );

            jumpsLeft--;
        }

        // GIRAR SPRITE
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }

        // ATAQUE
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.E)) {  
            animator.SetTrigger("Attack");
        }

        // ===== ANIMACIONES =====

        float speed = Mathf.Abs(moveInput);

        if (speed < 0.1f)
        {
            speed = 0f;
        }

        animator.SetFloat("Speed", speed);
        animator.SetBool("Grounded", isGrounded);
        animator.SetFloat("VerticalSpeed", rb.linearVelocity.y);
    }

    void FixedUpdate()
    {
        // MOVIMIENTO
        rb.linearVelocity = new Vector2(
            moveInput * moveSpeed,
            rb.linearVelocity.y
        );
    }

    // VER EL GROUNDCHECK EN EL EDITOR
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;

            Gizmos.DrawWireSphere(
                groundCheck.position,
                groundCheckRadius
            );
        }
    }
}
