using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Text gameOverText;
    [SerializeField] private Text resetInfoText;

    public void StopGame()
    {
        gameOverText.gameObject.SetActive(true);
        resetInfoText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
