using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{


    CameraController cameraController;
    

    public GameObject HowToPlayPanel;

    private void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
        
    }
    
   

    public void ReplayLevel() //replay level
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame() //Quit Game
    {
        SceneManager.LoadScene("Start");
    }

    public void NextLevel()
    {
        //next level scene
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            cameraController.StopGameSound();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            cameraController.PlayGameAudio();
        }
    }

    public void HowToPlay()
    {
        HowToPlayPanel.SetActive(true);
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Level-1");
    }





}
