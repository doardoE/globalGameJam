using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public void Interact() {
        GlobalVariable.isArmed = true;
        Destroy(this.gameObject);
    }
}
