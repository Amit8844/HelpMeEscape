using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
  //CameraController camController;
    private Animator _Door_Anim;
    private AudioSource _AudioSource;
    [SerializeField] private AudioClip _WinSound;

    public static bool nextLevel;
    public GameObject nextLevelPanel;


    private void Start()
    {
        _Door_Anim = gameObject.GetComponent<Animator>();
        _AudioSource = GetComponent<AudioSource>();
        

    }

   void OnTriggerEnter2D(Collider2D collision)
   
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level Completed");
            _Door_Anim.SetTrigger("Door");
            nextLevel = true;
           

            _AudioSource.clip = _WinSound;
            _AudioSource.Play();

            

            StartCoroutine(LevelEnd());
        }
    }

     IEnumerator LevelEnd()
    {
        if(nextLevel == true)
        {
            yield return new WaitForSeconds(2f);
            nextLevelPanel.SetActive(true);
        }
    }

   
}
