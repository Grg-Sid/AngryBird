using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;
    public Transform spawnPoint;
    public Rigidbody2D spawnRigidbody;
   
    public int spawnCount = 5;
    public int targetIndex;

    private GameObject currentBird;
    private bool gameEnd = false;

    private void Start()
    {
        SpawnBird();
    }

    private void Update()
    {
        if (spawnCount <= 0 && !gameEnd)
        {
            GameOver();
            return;
        }

        if (currentBird == null && spawnCount > 0 && !gameEnd)
        {
            spawnCount--;
            SpawnBird();
        }
    }
    private void GameOver()
    {
        Debug.Log("game over "+spawnCount);
        gameEnd = true;
        SceneManager.LoadScene(targetIndex);
    }
    public void SpawnBird()
    {
        Debug.Log(spawnCount);
        currentBird = Instantiate(birdPrefab, spawnPoint.position, Quaternion.identity);
        SpringJoint2D springJoint = currentBird.GetComponent<SpringJoint2D>();
        Rigidbody2D connectedBody = new GameObject("ConnectedBody").AddComponent<Rigidbody2D>();
        connectedBody = spawnRigidbody;
        springJoint.connectedBody = connectedBody;


        CameraController cameraController = FindObjectOfType<CameraController>();
        if (cameraController != null)
        {
            cameraController.SetTarget(currentBird.transform);
        }
    }
}
