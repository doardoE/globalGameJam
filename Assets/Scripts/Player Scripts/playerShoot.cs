using Unity.VisualScripting;
using UnityEngine;

public class playerShoot : MonoBehaviour
{   
    
    public bubbleProj bubble;
    public Transform cannon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootBubblesAction();

    }

    private void ShootBubblesAction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameObject bubbleProj = Instantiate(bubble.gameObject, cannon.position, cannon.rotation);
            bubbleProj currentBubble = bubbleProj.GetComponent<bubbleProj>();
            currentBubble.isFacingRight = transform.localScale.x == 1 ? true : false;
            currentBubble.player_mov = GetComponent<PlayerMovement>();
            BubbleManager.instance.AddBubbles(currentBubble);

        }
    }
}
