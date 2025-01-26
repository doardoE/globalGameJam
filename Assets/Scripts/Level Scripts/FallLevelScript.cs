using UnityEngine;
using UnityEngine.SceneManagement;

public class FallLevelScript : MonoBehaviour
{

    private string playerTag = "Player";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag(playerTag))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
