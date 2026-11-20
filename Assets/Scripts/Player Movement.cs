using UnityEngine;
using UnityEngine.InputSystem;

public class CustomizablePlatformerMovement : MonoBehaviour
{
    private static readonly int idle = Animator.StringToHash("Idle");
    private static readonly int running = Animator.StringToHash("Running");

    [Header("Components")]
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private BoxCollider2D groundCheckCollider;

    [Header("Movement")]
    [SerializeField] private float walkSpeed = 10f;
    [SerializeField] private float jumpHeight = 3f;
    
    private Vector2 moveInput;
    private Vector2 velocity;
    private float jumpForce => Mathf.Sqrt(2 * -Physics2D.gravity.y * jumpHeight);
    private bool pressedJump;
    
    private bool wasGrounded;
    private bool IsGrounded => groundCheckCollider.IsTouchingLayers(groundLayer);
    private LayerMask groundLayer;
    
    public bool ControlEnabled { get; set; } = true;
    
    [Header("Graphics")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        groundLayer = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        velocity = rigidbody.linearVelocity;
        if (wasGrounded && !IsGrounded)
        {
            if (velocity.y < 0)
            {
                // Has fallen. Play fall sound and/or trigger fall animation etc
            }
            else
            {
                // Has jumped. Play jump sound and/or trigger jump animation etc
            }
        }
        else if (!wasGrounded && IsGrounded)
        {
            // Has landed, play landing sound and trigger landing animation
        }
        
        velocity.x = moveInput.x * walkSpeed;
        if (pressedJump && wasGrounded) velocity = Vector2.up * jumpForce;
        animator.SetBool(running, velocity.x != 0);
        spriteRenderer.flipX = moveInput.x switch
        {
            > 0.01f => false,
            < -0.01f => true,
            _ => spriteRenderer.flipX
        };
        
        wasGrounded = IsGrounded;
        rigidbody.linearVelocity = velocity;
    }
    
    public void OnMove(InputAction.CallbackContext movementInput) => moveInput = ControlEnabled ? movementInput.ReadValue<Vector2>().normalized : Vector2.zero;
    
    public void OnJump(InputAction.CallbackContext jumpInput)
    {
        if (!ControlEnabled) return;
        if (jumpInput.started) pressedJump = true;
        if (jumpInput.canceled) pressedJump = false;
    }
}