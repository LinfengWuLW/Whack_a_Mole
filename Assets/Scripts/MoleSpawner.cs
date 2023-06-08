using UnityEngine;

public class MoleSpawner : MonoBehaviour
{
    public GameObject molePrefab;
    public Transform[] molePositions; // Array of transform positions where moles will be spawned

    public float spawnInterval = 2f; // Time interval between mole spawns

    private float timer = 0f;

    private void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if it's time to spawn a mole
        if (timer >= spawnInterval)
        {
            SpawnMole();

            // Reset the timer
            timer = 0f;
        }
    }

    private void SpawnMole()
    {
        // Randomly select a position index from the available molePositions array
        int randomIndex = Random.Range(0, molePositions.Length);

        // Get the selected position
        Transform spawnPosition = molePositions[randomIndex];

        // Instantiate a new mole at the selected position
        Instantiate(molePrefab, spawnPosition.position, spawnPosition.rotation);
    }
}
