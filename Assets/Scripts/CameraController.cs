using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private AudioSource _AudioSource;



    [SerializeField] private AudioClip _GameSound;

    void Start()
    {
        offset = transform.position - player.transform.position;
        _AudioSource = GetComponent<AudioSource>();
        PlayGameAudio();
       
    }
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

