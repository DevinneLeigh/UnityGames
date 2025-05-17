using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuController : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public string mainMenuSceneName = "MainMenu";
    public string gameSceneName = "Main"; 

    void Start()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true); 
        }

        Time.timeScale = 1f; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(gameSceneName);
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(mainMenuSceneName);
        }
    }
}