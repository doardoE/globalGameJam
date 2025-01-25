using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class bubbleProj : MonoBehaviour
{
    public bool isFacingRight = true;
    public float speed = 5f;
    public int count = 0;

    public float impulseForce = 50f;

    private string bubbleTag = "Bubble";

    public GameObject bigBubble;
    public bool isBigBubble = false;

    
    
    public PlayerMovement player_mov;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
        
    }
    IEnumerator ExampleCoroutine()
    {
        Debug.Log("Coroutine começou. Esperando 2 segundos...");
        // Espera 2 segundos
        yield return new WaitForSeconds(0.7f);

        Debug.Log("2 segundos se passaram. Fazendo algo...");
        speed = 0;

        yield return new WaitForSeconds(1.5f);
        DestroyAndRemoveBubbleFromList();

        Debug.Log("Finalizando a coroutine.");
    }

    private void DestroyAndRemoveBubbleFromList()
    {
        Destroy(this.gameObject);
        BubbleManager.instance.RemoveBubbles(this.gameObject.GetComponent<bubbleProj>());
    }

    // Update is called once per frame
    void Update()
    {
        BubbleMov();
       
    }

    private void BubbleMov()
    {
        transform.Translate((isFacingRight ? Vector3.right : Vector3.left) * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.TryGetComponent(out PlayerMovement playerM))
        {
            playerM.rb.AddForce(-other.contacts[0].normal * impulseForce, ForceMode2D.Impulse);
            DestroyAndRemoveBubbleFromList();
        }
        if (other.collider.CompareTag(bubbleTag) && !BubbleManager.instance.HasBigBubble())
        {
            
            GameObject bigBubbleGO = Instantiate(bigBubble, other.contacts[0].point, Quaternion.identity);
            bubbleProj currentBigBubble = bigBubbleGO.GetComponent<bubbleProj>();
            currentBigBubble.isBigBubble = true;
            BubbleManager.instance.AddBubbles(currentBigBubble);

            BubbleManager.instance.RemoveBubbles(other.gameObject.GetComponent<bubbleProj>());
            Destroy(other.gameObject);

            DestroyAndRemoveBubbleFromList(); 


        }
    }
   



}
