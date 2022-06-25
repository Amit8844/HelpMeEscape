using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour
{

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals ("Player"))
        {
            Invoke("DropPlatform", 0.3f);
            Destroy(gameObject, 2f);
        }
    }

    public void DropPlatform()
    {
        rb.isKinematic = false;
    }
}
