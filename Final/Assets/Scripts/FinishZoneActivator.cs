using UnityEngine;

public class FinishZoneActivator : MonoBehaviour
{
    public GameObject[] objectsToActivate;

    void Start()
    {
        if (objectsToActivate == null || objectsToActivate.Length != 7)
        {
            return;
        }

        int randomIndex = Random.Range(0, objectsToActivate.Length);
        objectsToActivate[randomIndex].SetActive(true);
    }
}
