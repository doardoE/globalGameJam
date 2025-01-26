using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    private int loadNextScene;
    private string playerTag = "Player";
    private void OnTriggerEnter2D(Collider2D other) {

        loadNextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (other.gameObject.CompareTag(playerTag))
        {
            SceneManager.LoadScene(loadNextScene);
            
        }
  }
}
