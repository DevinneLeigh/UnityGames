using UnityEngine;

public class VelocityScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float startSpeed = 50f;
    void Start()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        rigidBody.linearVelocity = new Vector3 (startSpeed, 0, startSpeed);
    }

    // Update is called once per frame

}
