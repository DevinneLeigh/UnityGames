using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject startStory;

    private bool onMainMenu = true;

    void Start()
    {
        mainMenu.SetActive(true);
        startStory.SetActive(false);
    }

    void Update()
    {
        if (onMainMenu)
        {
            if (Input.GetKeyDown(KeyCode.Return)) 
            {
                OnPlayButton();
            }
            else if (Input.GetKeyDown(KeyCode.Escape)) 
            {
                OnQuitButton();
            }
        }
        else 
        {
            if (Input.GetKeyDown(KeyCode.Return)) 
            {
                OnContinueButton();
            }
        }
    }

    // Simulated button behavior
    public void OnPlayButton()
    {
        mainMenu.SetActive(false);
        startStory.SetActive(true);
        onMainMenu = false;
    }

    public void OnContinueButton()
    {
        SceneManager.LoadScene("Main"); // Replace with your actual game scene name
    }

    public void OnQuitButton()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}