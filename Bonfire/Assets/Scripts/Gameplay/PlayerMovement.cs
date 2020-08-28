using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerControls playerControls;
    [SerializeField] private float _speed;
    Vector2 move;

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
        playerControls = new PlayerControls();

        playerControls.PlayerMovement.Movement.performed += ctx => { move = ctx.ReadValue<Vector2>(); };
        playerControls.PlayerMovement.Movement.canceled += ctx => { move = Vector2.zero; };
    }

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(move.normalized.x, 0, move.normalized.y) * Time.deltaTime * _speed;

        transform.forward = new Vector3(move.normalized.x, 0, move.normalized.y).normalized;
    }

    void Update()
    {

    }
}
