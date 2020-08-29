using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float gravityScale = 1.0f;
    private static float globalGravity = -9.81f;
    private Animator anim;
    public PlayerControls playerControls;
    [SerializeField] private float _speed;
    private Vector2 move;
    private bool jump = false;
    private bool grew = false;
    private Rigidbody rb;
    [SerializeField] private float jumpForce;
    private bool isTouchingGround;

    
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
    }
    public void OnMove(InputAction.CallbackContext value)
    {
        move = value.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        if (!GetComponent<PlayerTransitionCube>().IsTransitioning)
        {
            var transformDirection = transform.TransformDirection(Vector3.forward * move.magnitude * _speed * Time.deltaTime);
            rb.MovePosition(new Vector3(transform.position.x + transformDirection.x, transform.position.y, transform.position.z + transformDirection.z));
            if (new Vector3(move.x, 0, move.y) != Vector3.zero)
            {
                transform.forward = new Vector3(move.x, 0, move.y).normalized;
            }

            if (jump && isTouchingGround)
            {
                isTouchingGround = false;
                anim.SetBool("Jump", true);
                Jump();
            }
            else if (!jump && isTouchingGround)
            {
                jump = false;
                anim.SetBool("Jump", false);
            }
        }
    }

    void Update()
    {
        if (!GetComponent<PlayerTransitionCube>().IsTransitioning)
        {
            if (move.magnitude > 0)
            {
                anim.SetTrigger("Walking");
            }
            else 
            {
            anim.SetTrigger("Idle");
            }

        
            Vector3 gravity = globalGravity * gravityScale * Vector3.up;
            GetComponent<Rigidbody>().AddForce(gravity, ForceMode.Acceleration);
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    
    private void OnCollisionStay(Collision other)
    {
        if (other.transform.tag == "floor" && rb.velocity.y < .05 && rb.velocity.y > -.05)
        {
            jump = false;
            isTouchingGround = true;
        }
        else if (other.transform.tag == "scalableObject" && rb.velocity.y < .05 && rb.velocity.y > -.05)
        {

            
            if (!grew && transform.position.y > -10)
            {
                Debug.Log("exit col");
                grew = true;
                other.gameObject.GetComponent<Animator>().SetTrigger("grow");
            }
            jump = false;
            isTouchingGround = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.transform.tag == "floor")
        {
            isTouchingGround = false;
        }
        else if (other.transform.tag == "scalableObject" && rb.velocity.y > 0)
        {
            grew = false;
            isTouchingGround = false;
        }
    }

}
