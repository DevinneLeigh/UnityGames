using System.Collections;
using UnityEngine;

public class SequentialUICanvasManager : MonoBehaviour
{
    [System.Serializable]
    public class Message
    {
        public GameObject canvasObject;
        public float delayBefore = 1f;    
        public float displayDuration = 3f; 
    }

    public Message[] messages;

    void Start()
    {
        foreach (var message in messages)
        {
            if (message.canvasObject != null)
                message.canvasObject.SetActive(false);
        }

        StartCoroutine(PlayMessages());
    }

    IEnumerator PlayMessages()
    {
        foreach (var message in messages)
        {
            yield return new WaitForSeconds(message.delayBefore);

            if (message.canvasObject != null)
                message.canvasObject.SetActive(true);

            yield return new WaitForSeconds(message.displayDuration);

            if (message.canvasObject != null)
                message.canvasObject.SetActive(false);
        }
    }
}