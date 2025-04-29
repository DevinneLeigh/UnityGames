using UnityEngine;

public class GoalScript : MonoBehaviour
{

    public bool isSolved = false;

    void OnTriggerEnter(Collider other)
    {
        // GameObject collidedWith = GetComponent<Collider>().gameObject;

        if (other.tag == gameObject.tag)
        {
            isSolved = true;
            GetComponent<Light>().enabled = false;
            Destroy (other.gameObject);
        }
    }

}
