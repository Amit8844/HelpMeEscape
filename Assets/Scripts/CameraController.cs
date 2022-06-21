using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
     public GameObject player;


    private AudioSource _AudioSource;
    [SerializeField] private AudioClip _GameSound;

    Win win;

    private Vector3 offset;
     //Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        _AudioSource = GetComponent<AudioSource>();
        PlayGameAudio();
       
    }

   



    // Update is called once per frame
    void LateUpdate()
    {


        transform.position = player.transform.position + offset;
        
    }

   

    public void PlayGameAudio()
    {
        _AudioSource.clip = _GameSound;
        _AudioSource.Play();
    }
    
    public void StopGameSound()
    {
        _AudioSource.clip = _GameSound;
        _AudioSource.Stop();
    }




}

