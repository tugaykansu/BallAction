using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnCollision : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    
    private GameObject spark;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 spawnPoint = other.contacts[0].point;
            spark = Instantiate(prefab, spawnPoint, Quaternion.identity);
            spark.transform.parent = gameObject.transform;
            Invoke("DestroySpark", 0.1f);
        }
    }

    void DestroySpark()
    {
        Destroy(spark);
    }
}
