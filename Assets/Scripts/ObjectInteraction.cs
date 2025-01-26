using UnityEngine;
using System.Collections;


public class NPCInteraction : MonoBehaviour
{

    public PlayerMovement playerMove;
    public PlayerAnimationController playerAnime;

    public void Interact() {
        GlobalVariable.isArmed = true;
        playerAnime.PlayAnimation("PegandoArma");
        StartCoroutine(CoroutineItem());
        
        playerMove.speed = 8f;
        playerMove.jumpingPower = 16f;
      
    }

    IEnumerator CoroutineItem()
    {
        GlobalVariable.isPicking = true;
        playerMove.speed = 0f;
        playerMove.jumpingPower = 0f;

        yield return new WaitForSeconds(0.9f);
          GlobalVariable.isPicking = false;
          Destroy(this.gameObject);
    }
}
