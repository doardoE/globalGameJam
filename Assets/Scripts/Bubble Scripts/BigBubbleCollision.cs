using Unity.VisualScripting;
using UnityEngine;

public class BigBubbleCollision : MonoBehaviour
{
    private string PlayerTag = "Player";
    public GameObject playerBigBubble;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(PlayerTag))
        {
            Destroy(other.gameObject);
            var target = Instantiate(playerBigBubble, this.transform.position, this.transform.rotation);
            FindFirstObjectByType<CameraManager>().SetTarget(target.transform);

        }
       
    }
}
