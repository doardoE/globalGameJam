using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeDie : MonoBehaviour


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



      private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag(playerTag))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
