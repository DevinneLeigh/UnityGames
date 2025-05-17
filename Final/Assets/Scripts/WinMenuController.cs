using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenuController : MonoBehaviour
{
    public GameObject winCanvas;
    public string mainMenuSceneName = "MainMenu";
    public string gameSceneName = "Main"; 

    void Start()
    {
        if (winCanvas != null)
        {
            winCanvas.SetActive(true); 
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
