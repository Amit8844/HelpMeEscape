using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPower : MonoBehaviour
{
    [SerializeField] private AudioSource _PowerUp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
           
            BulletText.bulletAmount += 15;
            _PowerUp.Play();
            Destroy(gameObject,.7f);
            
        }
    }
}
