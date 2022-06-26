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

    public void QuitGame() 
    {
        SceneManager.LoadScene("Start");
    }

    public void NextLevel()
    {
        //next level scene
    }

    public void Pause()
    {
        cameraController.PlayGameAudio();
        Time.timeScale = Time.timeScale == 1 ? 0  : 1;
        cameraController.StopGameSound();
       

        
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
