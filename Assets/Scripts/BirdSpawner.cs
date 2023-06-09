using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;
    public Transform spawnPoint;
    public Rigidbody2D spawnRigidbody;
    public int spawnCount = 5;

    private GameObject currentBird;
    private bool gameEnd = false;

    private void Start()
    {
        SpawnBird();
        //spawnCount--;
        
    }

    private void Update()
    {
        if (currentBird == null && spawnCount > 0)
        {
            spawnCount--;
            SpawnBird();
        }

        if(spawnCount == 0 && !gameEnd) 
        {
            Debug.Log("Game Over");
            gameEnd = true;
        }
    }

    public void SpawnBird()
    {
        //spawnCount++;
        currentBird = Instantiate(birdPrefab, spawnPoint.position, Quaternion.identity);
        SpringJoint2D springJoint = currentBird.GetComponent<SpringJoint2D>();
        Rigidbody2D connectedBody = new GameObject("ConnectedBody").AddComponent<Rigidbody2D>();
        connectedBody = spawnRigidbody;
        springJoint.connectedBody = connectedBody;

        // Set the spawned bird as the target for the camera to follow
        CameraController cameraController = FindObjectOfType<CameraController>();
        if (cameraController != null)
        {
            cameraController.SetTarget(currentBird.transform);
        }
    }
}
