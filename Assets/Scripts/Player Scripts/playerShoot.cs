using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class playerShoot : MonoBehaviour
{   
    
    public bubbleProj bubble;
    public Transform cannon;
    public PlayerAnimationController playerAnime;
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
        if (Input.GetKeyDown(KeyCode.Mouse0)&& GlobalVariable.isArmed == true && GlobalVariable.isAttacking == false)
        {
            GameObject bubbleProj = Instantiate(bubble.gameObject, cannon.position, cannon.rotation);
            bubbleProj currentBubble = bubbleProj.GetComponent<bubbleProj>();
            currentBubble.isFacingRight = transform.localScale.x == 1 ? true : false;
            currentBubble.player_mov = GetComponent<PlayerMovement>();
            BubbleManager.instance.AddBubbles(currentBubble);

             StartCoroutine(CoroutineAttack());
        }
    }
    IEnumerator CoroutineAttack()
    {
        GlobalVariable.isAttacking = true;
        
        // Espera 2 segundos
        playerAnime.PlayAnimation("playerAtirandoComRisco");

        GameObject bubbleProj = Instantiate(bubble.gameObject, transform.position, transform.rotation);
        bubbleProj.GetComponent<bubbleProj>().isFacingRight = transform.localScale.x == 1 ? true : false;

        yield return new WaitForSeconds(0.5f);

        GlobalVariable.isAttacking = false;
    }
}
