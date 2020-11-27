using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    private GameOver gameOver;
    
    private void Start()
    {
        gameOver = GameObject.FindGameObjectWithTag("GameOver").GetComponent<GameOver>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameOver.StopGame();
        }
        
        Destroy(other.gameObject);
    }
}
