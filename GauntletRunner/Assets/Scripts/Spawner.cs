using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject powerupPrefab;
    public GameObject obstaclePrefab;
    public float spawnCycle = 0.5f;
    public GameManager manager;
    private float _elapsedTime;
    private bool _spawnPowerup = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > spawnCycle)
        {
            GameObject temp;

            if (_spawnPowerup)
            {
               temp = Instantiate(powerupPrefab) as GameObject; 
            }
            else
            {
                temp = Instantiate(obstaclePrefab) as GameObject;
            }
            
            Vector3 position = temp.transform.position;
            position.x = Random.Range(-3f, 3f);
            temp.transform.position = position;
            Collidable col = temp.GetComponent<Collidable>();
            col.manager = manager;
            _elapsedTime = 0;
            _spawnPowerup = !_spawnPowerup;
        }
    }
}
