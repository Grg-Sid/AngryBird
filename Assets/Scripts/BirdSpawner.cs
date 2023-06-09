using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;
    public Transform spawnPoint;
    public Rigidbody2D spawnRigidbody;

    private GameObject currentBird;

    private void Start()
    {
        SpawnBird();
    }

    private void Update()
    {
        if (currentBird == null)
        {
            SpawnBird();
        }
    }

    public void SpawnBird()
    {
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
