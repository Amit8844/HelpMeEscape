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
    private bool doubleJump;

    private Animator _Death_Anim;
    public GameObject gameOverPanel;
    public GameObject Gun;
    public GameObject ObjectToFollow;


    private CameraController _CameraController;
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
        _CameraController = FindObjectOfType<CameraController>();

    }
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        DoubleJump();
        Jump();

    }

    private void Jump()
    {
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void DoubleJump()
    {
        if (Input.GetButtonDown("Jump") && (IsGrounded() || doubleJump && !IsGrounded()))
        {
            doubleJump = !doubleJump;
            doubleJump = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);


            doubleJump = !doubleJump;
            _AudioSource.clip = _JumpSound;
            _AudioSource.Play();
            _animator.SetTrigger("Jump");
            _animator.SetTrigger("Trail");
        }
    }

    public bool IsGrounded()
    {

        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Trap")
        {
            _AudioSource.clip = _deathSound;
            _AudioSource.Play();
            _Death_Anim.Play("Death_Animation");
            Debug.Log("Death2");
            _CameraController.StopGameSound();
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



    






