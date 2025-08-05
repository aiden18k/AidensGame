using UnityEngine;
using System.Collections;

public class GroundTile : MonoBehaviour
{
    public Transform nextSpawnPoint;
    public float scrollSpeed = 5f;

    public GameObject[] obstaclePrefabs;
    public float minY = -1f;
    public float maxY = 1f;

    public int minObstacleCount = 1;
    public int maxObstacleCount = 3;
    public float timeBetweenSpawns = 0.5f;

    private bool tileSpawnedNext = false;

    void Start()
    {
        //StartCoroutine(SpawnObstaclesOverTime());
    }

    void Update()
    {
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !tileSpawnedNext)
        {
            //GroundSpawner.Instance.SpawnTile();
            tileSpawnedNext = true;
        }
    }

    private void OnBecameInvisible()
    {
        //Destroy(gameObject);
    }
    /*
    IEnumerator SpawnObstaclesOverTime()
    {
        int spawnCount = Random.Range(minObstacleCount, maxObstacleCount + 1);

        for (int i = 0; i < spawnCount; i++)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    void SpawnObstacle()
    {
        if (obstaclePrefabs.Length == 0) return;

        GameObject obstacle = Instantiate(
            obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)],
            transform.position + new Vector3(Random.Range(1f, 6f), Random.Range(minY, maxY), 0f),
            Quaternion.identity,
            this.transform // parent it to the tile
        );
    }
    */
}
