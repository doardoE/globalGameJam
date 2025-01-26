using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class bubbleProj : MonoBehaviour
{
    public bool isFacingRight = true;
    public float speed = 5f;
    public int count = 0;

    private string PlayerTag = "Player";

    public GameObject gameObjectPlayer;
    private  Rigidbody2D rb2D;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
        rb2D = gameObjectPlayer.GetComponent<Rigidbody2D>();
    }
    IEnumerator ExampleCoroutine()
    {
        Debug.Log("Coroutine começou. Esperando 2 segundos...");
        // Espera 2 segundos
        yield return new WaitForSeconds(0.7f);
        
        Debug.Log("2 segundos se passaram. Fazendo algo...");
        speed = 0;
        // Espera por uma condição (até que o tempo de jogo seja maior que 5 segundos)
        // yield return new WaitUntil(() => Time.time > 5f);
        
        // Debug.Log("Tempo de jogo ultrapassou 5 segundos. Continuando...");
        
        // Outro exemplo: esperar 3 frames
        // yield return new WaitForSeconds(3);
        
        Debug.Log("Finalizando a coroutine.");
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
    
     void OnCollisionEnter(Collision other)
    {
       if (other.gameObject.CompareTag(PlayerTag))
       {
        rb2D.AddForce(Vector2.up);
       } 
    }




}
