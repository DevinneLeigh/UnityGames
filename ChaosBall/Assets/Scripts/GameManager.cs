using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GoalScript blue, green, pink, orange;

    private bool isGameOver = true;

    // Update is called once per frame
    void Update()
    {
        isGameOver = blue.isSolved && green.isSolved && pink.isSolved && orange.isSolved;
    }

    void OnGUI()
    {
        if (isGameOver)
        {
            Rect rect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 75);
            GUI.Box(rect, "Game Over");
            Rect rect2 = new Rect(Screen.width / 2 - 30, Screen.height / 2 - 25, 60, 50);
            GUI.Label (rect2, "Good Job!");
        }
    }
}
