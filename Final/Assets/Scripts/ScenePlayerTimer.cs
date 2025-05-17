using UnityEngine;

public class ScenePlayTimer : MonoBehaviour
{
    public static ScenePlayTimer Instance;

    public float totalPlayTime = 0f;

    void Awake()
    {
        // Keep only one instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep timer across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    void Update()
    {
        totalPlayTime += Time.deltaTime;
    }
}