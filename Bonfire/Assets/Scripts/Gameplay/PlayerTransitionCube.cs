using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransitionCube : MonoBehaviour
{
    [SerializeField]private bool isTransitioning;
    [SerializeField]private bool move;
    [SerializeField]private float speed;

    public bool IsTransitioning 
    {
        set { isTransitioning = value; }
        get { return isTransitioning; }
    }

    public bool Move
    {
        set { move = value; }
        get { return move; }
    }

    void Start()
    {
        move = false;
        isTransitioning = false;
    }

    void Update()
    {
        if (move)
        {
            transform.position += (Vector3.up * Time.deltaTime * speed);
        }
    }
}
