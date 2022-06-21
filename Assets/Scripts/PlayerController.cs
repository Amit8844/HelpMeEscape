using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{

   

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    private Animator _Death_Anim;

    public GameObject gameOverPanel;
    public GameObject Gun;


    public GameObject ObjectToFollow;




    private bool doubleJump;
    
    private AudioSource _AudioSource;
    
  
    [SerializeField] private AudioClip _JumpSound;
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator _animator;

   

    private void Start()
    {

        _animator = GetComponent<Animator>();
        _AudioSource = GetComponent<AudioSource>();
        _Death_Anim = gameObject.GetComponent<Animator>();
      
       
    }

   



    private void Update()
    {
         horizontal = Input.GetAxisRaw("Horizontal");
        
        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                doubleJump = !doubleJump;
                _AudioSource.clip = _JumpSound;
                _AudioSource.Play();
                _animator.SetTrigger("Jump");
            }


            if (!IsGrounded())
            {
                doubleJump = false;
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    
    }
      public bool IsGrounded()
    {
      
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Trap" ) 
        {
            _AudioSource.clip = _deathSound;
            _AudioSource.Play();
            _Death_Anim.Play("Death_Animation");

            // ObjectToFollow.transform.parent = null;
            Debug.Log("Death2");
            StartCoroutine(Death());

           
           
        }
        
     }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
        Gun.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);

        Debug.Log("Death");

    }

   
    


    
   
}



    






