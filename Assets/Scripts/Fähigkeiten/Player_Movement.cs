using UnityEngine;
using UnityEngine.InputSystem;

public class BetterTest : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        // Bewegung
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Sprite flippen
        if (moveInput > 0.01f)
            spriteRenderer.flipX = false;
        else if (moveInput < -0.01f)
            spriteRenderer.flipX = true;

        // Springen
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.y, jumpForce);
        }

        // Bodencheck
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        /*if ( isGrounded == true)
        {
            Debug.Log("Player is Grounded");
        } */
    }
}