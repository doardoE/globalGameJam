using UnityEngine;

public class playerShoot : MonoBehaviour
{   
    
    public bubbleProj bubble;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bubbleProj = Instantiate(bubble.gameObject, transform.position, transform.rotation);
            bubbleProj currentBubble = bubbleProj.GetComponent<bubbleProj>();
            currentBubble.isFacingRight = transform.localScale.x == 1 ? true : false;
            currentBubble.player_mov = GetComponent<PlayerMovement>();
          

        }
        
    }
}
