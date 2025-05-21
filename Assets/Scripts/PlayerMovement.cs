using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float jumpForce = 5f; 
    public LayerMask groundLayer; 
    private bool isFacingRight = true; 
    private Animator anim; 
    private Rigidbody2D rb; 
    private bool isGrounded = false;
    public GameObject dialoguePanel;
    public Transform Player;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Player.transform.position = new Vector3(-4.24f, 1f, 0f);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!dialoguePanel.activeInHierarchy)
        {
            if (!anim.GetBool("FallInWell"))
            {
                isGrounded = IsGrounded();

                float moveInput = Input.GetAxis("Horizontal");

                transform.Translate(Vector3.right * moveInput * moveSpeed * Time.deltaTime);

                if (Mathf.Abs(moveInput) > 0.01f)
                {
                    anim.SetBool("isRunning", true);
                }
                else
                {
                    anim.SetBool("isRunning", false);
                }

                if (moveInput > 0 && !isFacingRight)
                {
                    Flip();
                }
                else if (moveInput < 0 && isFacingRight)
                {
                    Flip();
                }

                if (Input.GetButtonDown("Jump") && isGrounded)
                {
                    Jump();
                }
            }
            
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x = -localScale.x; 
        transform.localScale = localScale;

        isFacingRight = !isFacingRight;
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private bool IsGrounded()
    {
        
        return Physics2D.OverlapCircle(transform.position - new Vector3(0, 0.1f, 0), 0.01f, groundLayer);
    }
}

