using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private bool isNearInteractable = false;// verifica se está próximo
    private GameObject interactableObject; // referencia ao objeto interagivel

    void Update() {
        // detecta se o jogador pressionou a tecla de interação (ex: E)
        if (isNearInteractable && Input.GetKeyDown(KeyCode.E)) {

            // chama o metodo de interaçao do objeto

            if (interactableObject != null) {
                interactableObject.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    // detecta se o jogador entrou no trigger do objeto
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Interactable")) {
            isNearInteractable = true;
            interactableObject = collision.gameObject;
        }
    }

    // detecta se o player saiu do trigger do objeto
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Interactable")) {
            isNearInteractable = false;
            interactableObject = null;
        }
    }
}
