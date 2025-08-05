using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;
public class GroundSpawner : MonoBehaviour
{
    public GameObject spawnPrefab;
    public Transform startPoint;
    public Transform endPoint;
    public float spawnThreshold; // how close player gets to furthest tile before spawning a new one
    public int maxBoxesOnScreen = 5;
    public float scrollSpeed = 9f;
    public float timer = 0;
    private Camera cam;
    Vector3 bottomLeft;
    Vector3 topRight;
    void Start()
    {
        cam =  Camera.main;
        bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));
        // Create starting tiles
            SpawnTile();
    }
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (timer >= spawnThreshold)
        {
            timer = 0;
            SpawnTile();
        }
    }
    public void SpawnTile()
    {
        float randomY = Random.Range(bottomLeft.y, topRight.y);
        Vector3 spawnPosition = new Vector3(startPoint.position.x, randomY, 0);
        Instantiate(spawnPrefab, spawnPosition, Quaternion.identity);
    }
}