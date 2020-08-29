using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionCube : MonoBehaviour
{

    [SerializeField] private bool isTransitioning;
    [SerializeField] private bool drop;

    public bool IsTransitioning
    {
        set { isTransitioning = value; }
        get { return isTransitioning; }
    }
    public bool Drop
    {
        set { drop = value; }
        get { return drop; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTransitioning)
        {
            isTransitioning = false;
            PlayerTransitionCube[] players = FindObjectsOfType<PlayerTransitionCube>();
            foreach(PlayerTransitionCube p in players)
            {
                p.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                p.Move = true;
                p.IsTransitioning = true;
            }
            FindObjectOfType<CubeRotation>().Rotate = true;
        }

        if (drop)
        {
            PlayerTransitionCube[] players = FindObjectsOfType<PlayerTransitionCube>();
            foreach (PlayerTransitionCube p in players)
            {
                p.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                p.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
                p.IsTransitioning = false;
                p.Move = false;
            }
            drop = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerTransitionCube>().Move = false;

        }
    }
}
