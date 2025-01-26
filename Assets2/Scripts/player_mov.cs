using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    public bool isFacingRight = true;
    public PlayerAnimationController playerAnime;
    public float vertical;
    

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start() {
        GlobalVariable.isArmed = false;
        GlobalVariable.isAttacking = false;
        GlobalVariable.isPicking = false;
    }

    void Update()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = rb.linearVelocity.y;

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }

        if (vertical > 0 && GlobalVariable.isAttacking == false) {
            playerAnime.PlayAnimation("playerPuloSubida");
        }

        else if (vertical < 0 && GlobalVariable.isAttacking == false) {
            playerAnime.PlayAnimation("playerPuloQueda");
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
            if (GlobalVariable.isArmed == false) {
                if (horizontal != 0 && vertical == 0 && GlobalVariable.isPicking == false){
                    playerAnime.PlayAnimation("Run");
                }
                else if (horizontal == 0 && vertical == 0 && GlobalVariable.isPicking == false){
                    playerAnime.PlayAnimation("idle");
                }
            }
            else if (GlobalVariable.isArmed == true && GlobalVariable.isAttacking == false) {
                if (horizontal != 0 && vertical == 0 && GlobalVariable.isPicking == false) {
                    playerAnime.PlayAnimation("Run");
                }
                else if (horizontal == 0 && GlobalVariable.isAttacking == false && vertical == 0 && GlobalVariable.isPicking == false) {
                    playerAnime.PlayAnimation("idleArmado");
                }  
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