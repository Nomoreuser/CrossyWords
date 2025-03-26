using UnityEngine;

public class CarManager : MonoBehaviour
{
    public GameObject[] carPrefabs;  // Drag multiple car prefabs here
    public Transform spawnPoint;
    public Transform targetPoint;  // The endpoint for cars
    public float minSpawnInterval = 2f;
    public float maxSpawnInterval = 5f;

    void Start()
    {
        Invoke(nameof(SpawnCar), Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    void SpawnCar()
    {
        if (carPrefabs.Length == 0) return;

        int randomIndex = Random.Range(0, carPrefabs.Length);
        GameObject newCar = Instantiate(carPrefabs[randomIndex], spawnPoint.position, spawnPoint.rotation);

        CarMovement carMovement = newCar.AddComponent<CarMovement>();
        carMovement.speed = Random.Range(5f, 15f);
        carMovement.targetPoint = targetPoint;  // Assign target
        Invoke(nameof(SpawnCar), Random.Range(minSpawnInterval, maxSpawnInterval));
    }
}

public class CarMovement : MonoBehaviour
{
    public float speed = 10f;
    public Transform targetPoint;

    void Start()
    {
        if (targetPoint != null)
        {
            // Rotate the car to face the target
            transform.LookAt(targetPoint);
        }
    }

    void Update()
    {
        if (targetPoint != null)
        {
            // Move towards the target
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        }

        // Destroy when reaching the target
        if (targetPoint && Vector3.Distance(transform.position, targetPoint.position) < 0.5f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jammo got hit! Game Over!");
            other.GetComponent<PlayerDeath>().Die();
        }

        void OnTriggerEnter(Collider other)
        {
            Debug.Log("Collided with: " + other.gameObject.name);
        }

    }

}
