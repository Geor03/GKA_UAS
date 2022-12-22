using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour{

    public static bool GameIsPaused;
    public GameObject pauseMenuUI;

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            }else{
                Paused();
            }
        }
    }

    public void Resume (){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Paused (){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame(){
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}

