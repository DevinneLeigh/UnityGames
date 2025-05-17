using UnityEngine;
using TMPro;

public class ShowPlayTime : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    void Start()
    {
        if (ScenePlayTimer.Instance != null)
        {
            float time = ScenePlayTimer.Instance.totalPlayTime;

            int minutes = Mathf.FloorToInt(time / 60f);
            int seconds = Mathf.FloorToInt(time % 60f);

            timeText.text = $"Play Time: {minutes:D2}:{seconds:D2}";
        }
        else
        {
            timeText.text = "Play Time: N/A";
        }
    }
}