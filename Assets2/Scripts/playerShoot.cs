using UnityEngine;
using System.Collections;

public class playerShoot : MonoBehaviour
{   
    
    public bubbleProj bubble;
    public PlayerAnimationController playerAnime;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && GlobalVariable.isArmed == true && GlobalVariable.isAttacking == false)
        {
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
