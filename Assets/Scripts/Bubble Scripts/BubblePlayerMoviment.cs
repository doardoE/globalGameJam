using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BubblePlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    public bool isFacingRight = true;
    public GameObject player;

    public Rigidbody2D rb;

    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        Flip();
    }
    void Start()
    {
       
    }
    
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);

        if (Input.GetKey(KeyCode.Space))
        {
            Destroy(this.gameObject);
            var target = Instantiate(player, this.transform.position, this.transform.rotation);
            FindFirstObjectByType<CameraManager>().SetTarget(target.transform);
        }

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