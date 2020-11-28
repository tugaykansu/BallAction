using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private ScoreController scoreController;
    
    private void OnTriggerEnter(Collider other)
    {
        if (! other.gameObject.CompareTag("Player"))
        {
            scoreController.ChangeScore(10);
        }
        
    }
}
