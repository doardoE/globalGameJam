using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    public bool isFacingRight = true;
    public PlayerAnimationController playerAnime;
    

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    void Update()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }

        if (Input.GetKeyUp(KeyCode.Space) && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
            if (GlobalVariable.isArmed == false) {
                if (horizontal != 0){
                    playerAnime.PlayAnimation("Run");
                }
                else if (horizontal == 0){
                    playerAnime.PlayAnimation("idle");
                }
            }
            else if (GlobalVariable.isArmed == true) {
                
            }
            
        

        Flip();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
       
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

            
        }
    }
}