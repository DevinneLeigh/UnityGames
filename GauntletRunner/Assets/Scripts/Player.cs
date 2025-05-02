using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")] 
    public GameManager manager;
    public Material normalMat;
    public Material phasedMat;

    [Header("Gameplay")] 
    public float bounds = 3f;
    public float strafeSpeed = 4f;
    public float phaseCooldown = 2f;

    private Renderer _mesh;
    private Collider _collision;
    bool _canPhase = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        _collision = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal") * Time.deltaTime * strafeSpeed;
        
        Vector3 position = transform.position;
        position.x += xMove;
        position.x = Mathf.Clamp(position.x, -bounds, bounds);
        transform.position = position;

        if (Input.GetButtonDown("Jump") && _canPhase)
        {
            _canPhase = false;
            _mesh.material = phasedMat;
            _collision.enabled = false;
            
            Invoke(nameof(PhaseIn), phaseCooldown);
        }
    }

    void PhaseIn()
    {
        _canPhase = true;
        _mesh.material = normalMat;
        _collision.enabled = true;
    }
}
