using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextureScroller ground;
    public float gameTime = 10;

    private float _totalTimeElapsed = 0;
    bool _isGameOver = false;

    // Update is called once per frame
    void Update()
    {
        if (_isGameOver)
        {
            return;
        }
        
        _totalTimeElapsed += Time.deltaTime;
        gameTime -= Time.deltaTime;

        if (gameTime <= 0)
        {
            _isGameOver = true;
        }
    }

    public void AdjustTime(float amount)
    {
        gameTime += amount;
        if (amount < 0)
        {
            SlowWorldDown();
        }
    }

    void SlowWorldDown()
    {
        CancelInvoke();
        Time.timeScale = 0.5f;
        Invoke(nameof(SpeedWorldUp), 1);
    }

    void SpeedWorldUp()
    {
        Time.timeScale = 1f;
    }

    void OnGUI()
    {
        if (!_isGameOver)
        {
            Rect boxRect = new Rect(Screen.width / 2 - 50, Screen.height -100, 100, 50);
            GUI.Box(boxRect, "Time Remaining");
            
            Rect labelRect = new Rect(Screen.width / 2 - 10, Screen.height -80, 20, 40);
            GUI.Label(labelRect, ((int)gameTime).ToString());
        }
        else
        {
            Rect boxRect = new Rect(Screen.width / 2 - 60, Screen.height / 2 - 100, 120, 50);
            GUI.Box(boxRect, "Game Over");
            
            Rect labelRect = new Rect(Screen.width / 2 - 55, Screen.height / 2 - 80, 90, 40);
            GUI.Label(labelRect, "Total Time: " + (int)_totalTimeElapsed);

            Time.timeScale = 0;
        }
    }
}
