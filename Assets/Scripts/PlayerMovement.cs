using System.Collections;
using UnityEngine;

// --- Reference(s) ---
// Movement code from: bendux
// ASWD movement -
// Reference: https://www.youtube.com/watch?v=K1xZ-rycYY8
// https://gist.github.com/bendux/5fab0c176855d4e37bf6a38bb071b4a4
// Flip code from: Dani Krossing
// Reference: https://www.youtube.com/watch?v=Cr-j7EoM8bg


// Dashing movement - 
// Reference: https://www.youtube.com/watch?v=2kFGmuPHiA0
// https://gist.github.com/bendux/aa8f588b5123d75f07ca8e69388f40d9

public class PlayerMovement : MonoBehaviour
{
    // Normal movement variables
    private float inputHorizontal;
    private float inputVertical;
    [SerializeField] private float speed = 7f;
    [SerializeField] private float jumpingPower = 14f;
    private bool isFacingRight = true;

    // Dash movement variables
    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 15f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    // Unity component variables
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;

    // Sound variables
    [SerializeField] private AudioSource jumpSoundEffect;

    
    // Knockback variables
    public float knockTimer = 0f;
    public float knockTotalTime = 1.5f; 

    // Start 
    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update movement
    private void Update()
    {
        // - Player can't move? -
        // Prevent other movement while player dashing
        if (isDashing)
        {
            return;
        }
        // Countdown knockback timer if mid knockup
        if (knockTimer > 0)
        {
            knockTimer -= Time.deltaTime;
            // Force gets applied in enemy collision function
            return;
        }

        // - Get inputs -
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        // Apply x movement force
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);
        
        // - Jumping -
        // Holding down jump produces a stronger jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower); 
            jumpSoundEffect.Play();
        }
        // Tapping down jump produces a weaker jump
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        // - Dashing -
        // Add dash inputs on "left shift" key
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        // - Flip? -
        // Check if flipping character sprite necessary
        if (((inputHorizontal > 0) && !isFacingRight) || ((inputHorizontal < 0) && isFacingRight))
        {
            Flip();
        }
    }

    // Function to check if player is on ground
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 1f, groundLayer);
    }

    // Set sprite displayed direction function
    private void Flip()
    {   // Get current scale of player
        transform.Rotate(0f, 180f, 0f);
        isFacingRight = !isFacingRight;
    }

    // Dash function
    private IEnumerator Dash()
    {
        // Get horizontal input 
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        // Once player is dashing, ensure dashing not allowed within a dash movement
        canDash = false;
        isDashing = true;

        // Stop gravity physics application during dash & store old gravity value
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(inputHorizontal * dashingPower, 0f);

        // Show trail emitter for a limited time
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;

        // Reset gravity back to original value
        rb.gravityScale = originalGravity;

        // Reset dash to 'allowed' state after dash cooldown
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

}