using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float gravityScale = 1.0f;
    private static float globalGravity = -9.81f;
    private Animator anim;
    private SoundEvent soundEvent;
    public PlayerControls playerControls;
    [SerializeField] private float _speed;
    private Vector2 move;
    private bool jump = false;
    private bool isJumping = false;
    private bool jumpRequest = false;
    private bool grew = false;
    private Rigidbody rb;
    [SerializeField] private float jumpForce;
    private bool isTouchingGround;

    private float stepsSeparationTimer;
    public float stepsSeparationTime;
    private bool step1;


    public Animator Anim
    {
        set { anim = value; }
        get { return anim; }
    }
    public bool IsJumping
    {
        set { isJumping = value; }
    }
    private void OnEnable()
    {
        playerControls.PlayerMovement.Enable();
    }

    private void OnDisable()
    {
        playerControls.PlayerMovement.Disable();
    }

    private void Awake()
    {
        soundEvent = GetComponent<SoundEvent>();
        jumpRequest = false;
        isJumping = true;
        rb = GetComponent<Rigidbody>();
        playerControls = new PlayerControls();
        anim = GetComponentInChildren<Animator>();
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            
            jump = true;
        }
        else if (value.canceled)
        {
            jump = false;
        }
    }
    public void OnMove()
    {
        move = new Vector2(Input.GetAxis("Horizontal" + name[0]), Input.GetAxis("Vertical" + name[0]));
    }


    void Update()
    {
        OnMove();
        if (!GetComponent<PlayerTransitionCube>().IsTransitioning)
        {
            if (move.magnitude > 0)
            {
                if (stepsSeparationTimer > stepsSeparationTime && !isJumping)
                {
                    stepsSeparationTimer = 0;
                    if (step1)
                    {
                        step1 = false;
                        PlaySound(1);
                    }
                    else
                    {
                        step1 = true;
                        PlaySound(2);
                    }
                }
                anim.SetTrigger("Walking");
            }
            else
            {
                anim.SetTrigger("Idle");
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isJumping)
        {

            anim.SetBool("Jump", false);
        }
        else
        {
            anim.SetBool("Jump", true);
        }

        if (name[0] == '1')
        {
            if (Input.GetKey(KeyCode.Joystick1Button0) && !isJumping)
            {

                jumpRequest = true;
                isJumping = true;

            }
        }
        else if (name[0] == '2')
        {
            if (Input.GetKey(KeyCode.Joystick2Button0) && !isJumping)
            {

                jumpRequest = true;
                isJumping = true;

            }
        }

        

        stepsSeparationTimer += Time.deltaTime;

        if (!GetComponent<PlayerTransitionCube>().IsTransitioning)
        {
            


            Vector3 gravity = globalGravity * gravityScale * Vector3.up;
            GetComponent<Rigidbody>().AddForce(gravity, ForceMode.Acceleration);
        }
        if (jumpRequest)
        {
            Jump();
            jumpRequest = false;
        }

        if (!GetComponent<PlayerTransitionCube>().IsTransitioning)
        {
            var transformDirection = transform.TransformDirection(Vector3.forward * move.magnitude * _speed * Time.deltaTime);
            rb.MovePosition(new Vector3(transform.position.x + transformDirection.x, transform.position.y, transform.position.z + transformDirection.z));
            if (new Vector3(move.x, 0, move.y) != Vector3.zero)
            {
                transform.forward = new Vector3(move.x, 0, move.y).normalized;
            }

            
        }
    }

    public void PlaySound(int index)
    {
        soundEvent.PlayClipByIndex(index);
    }

    void Jump()
    {
        soundEvent.PlayClipByIndex(0);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }


    //private void OnCollisionStay(Collision collision)
    //{
    //    rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
    //}

}
