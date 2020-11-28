using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    private float score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score : " + score;
    }

    public void ChangeScore(float delta)
    {
        
        score += delta;
        scoreText.text = "Score : " + score;
    }
}
