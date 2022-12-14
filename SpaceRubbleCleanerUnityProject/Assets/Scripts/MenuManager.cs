using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] 
    private Canvas menuCanvas;
    [SerializeField] 
    private Canvas uiCanvas;

    private bool paused;
    private Scene currentScene;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        paused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            Time.timeScale = 0;
            paused = true;
            uiCanvas.gameObject.SetActive(false);
            menuCanvas.gameObject.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            Time.timeScale = 0;
            paused = false;
            uiCanvas.gameObject.SetActive(true);
            menuCanvas.gameObject.SetActive(false);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentScene.name);
    }

    public void LoadOtherScene()
    {
        Time.timeScale = 1;
        
        if (currentScene.name == "SceneWithGravityAttractors")
        {
            SceneManager.LoadScene("SceneWithAreaAttractors");
        }
        else if(currentScene.name == "SceneWithAreaAttractors")
        {
            SceneManager.LoadScene("SceneWithGravityAttractors");
        }
        else
        {
            uiCanvas.gameObject.SetActive(true);
            menuCanvas.gameObject.SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
