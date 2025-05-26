using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Speed of the player movement
    [SerializeField] private float jumpForce = 10f; // Force applied when the player jumps
    [SerializeField] private LayerMask groundLayer; // Layer mask to identify ground objects
    [SerializeField] private Transform groundCheck; // Transform to check if the player is grounded
    private bool isGrounded; // Flag to check if the player is on the ground
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private Animator animator;

    private GameManager gameManager; // Reference to the GameManager script
    private AudioManager audioManager; // Reference to the AudioManager script


    void Awake(){
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player GameObject
        animator = GetComponent<Animator>(); // Get the Animator component attached to the player GameObject
        gameManager = FindFirstObjectByType<GameManager>(); // Find the GameManager in the scene
        audioManager = FindFirstObjectByType<AudioManager>(); // Find the AudioManager in the scenes
    }
    void Update()
    {
        if(gameManager.IsGameOver() || gameManager.IsGameWin() ) return; 
        HandleMovement();
        HandleJump(); 
        UpdateAnimation(); 
    }

    private void HandleMovement(){
        float moveInput = Input.GetAxis("Horizontal"); 
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        if(moveInput > 0) transform.localScale = new Vector2(1,1);
        else if(moveInput < 0) transform.localScale = new Vector2(-1,1); 
    }

    private void HandleJump(){
        if(Input.GetButtonDown("Jump") && isGrounded){ 
            rb.linearVelocity = new Vector2(rb.linearVelocity.x,jumpForce);
            audioManager.PlayJumpSound();
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); // 
    }

    private void UpdateAnimation(){
        bool isRunning = Mathf.Abs(rb.linearVelocity.x) > 0.1f; // Check if the player is running based on horizontal velocity
        bool isJumping = Mathf.Abs(rb.linearVelocity.y) > 0.1f; // Check if the player is jumping based on vertical velocity
        animator.SetBool("isRunning", isRunning); // Set the "isRunning" parameter in the Animator
        animator.SetBool("isJumping", isJumping); // Set the "isJumping" parameter in the Animator
    }
}
