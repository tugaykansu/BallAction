using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ResetScene : MonoBehaviour
{
    public string ResetKey = "r";
        
    void Update()
    {
        if(Input.GetKeyDown(ResetKey))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }
}
