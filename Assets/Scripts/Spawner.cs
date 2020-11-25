using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float period = 5;
    
    private Vector3 spawnCenter;
    
    
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    [SerializeField] private GameObject prefab;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        GameObject platform = GameObject.FindGameObjectWithTag("Respawn");
        spawnCenter = platform.transform.position; // + Vector3.up * 5;
        
        InstantiatePeriodically();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiatePeriodically()
    {
        Vector2 rand= Random.insideUnitCircle * 6;
        Vector3 spawnPoint = spawnCenter + new Vector3(rand.x, 0, rand.y);
        GameObject ball = Instantiate(prefab, spawnPoint, Quaternion.identity);
        
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        Transform tra = ball.GetComponent<Transform>();
        MoveToPoint mtp = ball.GetComponent<MoveToPoint>();
        
        tra.localScale *= Random.Range(0.5f, 2.0f);
        rb.mass *= Random.Range(0.5f, 2.0f);
        mtp.ScaleMovePower(Random.Range(0.5f, 2.0f));
        mtp.ScaleMaxAngularVelocity(Random.Range(0.5f, 2.0f));
        
        
        Invoke("InstantiatePeriodically", period);
    }
}
