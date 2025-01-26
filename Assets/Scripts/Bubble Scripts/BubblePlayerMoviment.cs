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
    public PlayerAnimationController playerAnime;

    [SerializeField] private LayerMask groundLayer;

    private string spikeTag = "Spike";

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
    }
    void Start()
    {
     StartCoroutine(ExampleCoroutine());
    }
    
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);

        if (Input.GetKey(KeyCode.Space))
        {
           DestroyBubbleControlSpawnPlayer();
           
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


    





    IEnumerator ExampleCoroutine()
    {
        Debug.Log("Coroutine começou. Esperando 1 segundo...");
        // Espera 2 segundos
        yield return new WaitForSeconds(5.5f);

        Debug.Log("2 segundos se passaram. Fazendo algo...");
        DestroyBubbleControlSpawnPlayer();
      

        Debug.Log("Finalizando a coroutine.");
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(spikeTag))
        {
             DestroyBubbleControlSpawnPlayer();
        }
           
    }

    private void DestroyBubbleControlSpawnPlayer()
    {
        Destroy(this.gameObject);

        var target = Instantiate(player, this.transform.position, this.transform.rotation);
        FindFirstObjectByType<CameraManager>().SetTarget(target.transform);
        GlobalVariable.isArmed = true;
    }
}