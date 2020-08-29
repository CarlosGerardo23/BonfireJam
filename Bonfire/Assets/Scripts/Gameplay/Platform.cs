﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (transform.tag == "scalableObject" && !transform.parent.transform.parent.GetComponent<GrowthScript>().animPlaying) 
            {
                transform.parent.transform.parent.GetComponent<GrowthScript>().Grow = true;
                
            }
            collision.gameObject.GetComponent<PlayerMovement>().IsJumping = false;
        }
    }
}
