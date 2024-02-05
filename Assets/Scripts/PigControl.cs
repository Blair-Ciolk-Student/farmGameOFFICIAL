using UnityEngine;


public class PigControl : MonoBehaviour
{

    [Header("Movement")]
    public float horizontal = 0f;
    private readonly float speed = 8f;
    public float jumpingPower = 16f;
    private enum MovementState { idle, walking, jump, falling }

    [Header("Ground Check")]
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    [Header("Flipping & Animation")]



    private Animator _animator;
    public Rigidbody2D rb;
    public SpriteRenderer sp;

    [Header("Misc/Unsorted")]
    public bool isFacingRight = true;


    [Header("Collection")]
    public GameManager gm;

    [Header("Audio")]
    private bool isPlayingFootSound = false;
    public AudioSource audSource;
    public AudioClip jumpSound, footSound;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        audSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");


        Jump();
        Flip();

    }
    private bool IsGrounded()
    {

        return Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

    }

    private void FixedUpdate()
    {
        IsGrounded();

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (horizontal != 0 && IsGrounded() && !isPlayingFootSound) // Check if moving horizontally, grounded, and not already playing foot sound
        {
            audSource.clip = footSound;
            audSource.Play();
            isPlayingFootSound = true; // Set flag to indicate that the sound is playing
        }
        else if (horizontal == 0 || !IsGrounded())
        {
            isPlayingFootSound = false; // Reset the flag when not moving horizontally or not grounded
            audSource.Stop();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Touching {collision.gameObject.name}", this);
    }

    void Jump()
    {

        bool grounded = IsGrounded();

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            audSource.clip = jumpSound;
            audSource.Play();

        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f && grounded)
        {
            audSource.clip = jumpSound;
            audSource.Play();

            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }


    }

    private void Flip()
    {
        MovementState state;

        if (horizontal > 0f)
        {
            state = MovementState.walking;

            sp.flipX = false;
        }
        else if (horizontal < 0f)
        {

            state = MovementState.walking;
            sp.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        _animator.SetInteger("state", (int)state);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(feetPos.position, checkRadius);
    }


}