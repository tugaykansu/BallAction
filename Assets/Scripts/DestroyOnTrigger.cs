using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    private GameOver gameOver;
    private LevelController levelController;
    
    private void Start()
    {
        gameOver = GameObject.FindGameObjectWithTag("GameOver").GetComponent<GameOver>();
        levelController = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameOver.StopGame();
        }
        else
        {
            levelController.NextLevel();
        }
        
        Destroy(other.gameObject);
        
    }
}
