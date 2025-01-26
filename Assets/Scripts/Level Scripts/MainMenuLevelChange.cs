using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLevelChange : MonoBehaviour
{
      private int loadNextScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       

    }

    public void ChangeLevelFunc()
    {
        loadNextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(loadNextScene);
        if (loadNextScene >= SceneManager.sceneCount)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
