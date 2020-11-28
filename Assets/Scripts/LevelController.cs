using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public bool playerOnPlatform = true;
    [SerializeField] private List<GameObject> levels;
    [SerializeField] private Text centerText;

    private int currentLevel = 0;
    private int numberOfLevels;
    
    private GameOver gameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        numberOfLevels = levels.Count;
        levels[0].SetActive(true);
        for (int i = 1; i < numberOfLevels; i++)
        {
            levels[i].SetActive(false);
        }
    }

    public void NextLevel()
    {
        if (!playerOnPlatform)
        {
            return;    // DestroyOnTrigger
        }

        if (currentLevel + 1 == numberOfLevels)
        {
            EndGame();
        }
        else
        {
            EndLevel(currentLevel);
            StartLevel(currentLevel+1);
        }

        currentLevel++;
    }

    private void StartLevel(int i)
    {
        levels[i].SetActive(true);
    }
    
    private void EndLevel(int i)
    {
        levels[i].SetActive(false);
    }
    
    private void EndGame()
    {
        if (playerOnPlatform)
        {
            centerText.gameObject.SetActive(true);
            centerText.text = "VICTORY";
        }
    }
}
