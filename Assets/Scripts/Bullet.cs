using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHit;

    public GameObject Effect;

     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }
   void Update()
    {
        HasHit();
    }
   
    private void HasHit()
    {
        if (hasHit == false)
        {
            float angle = Mathf.Atan2(rb.velocity.x, rb.velocity.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)

    {
        BulletEffect(other);

    }

    private void BulletEffect(Collision2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ground" || other.gameObject.tag == "Trap")
        {
            hasHit = true;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            PlayEffect();




        }
    }

    private void PlayEffect()
    {
        Particals();

        StartCoroutine(DestroyBullet());
    }

    private void Particals()
    {
        rb.velocity = Vector2.zero;

        Effect.SetActive(true);

        Effect.transform.position = transform.position;
        ParticleSystem[] effects = Effect.transform.GetComponentsInChildren<ParticleSystem>();

        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].Play();
        }
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }




}
