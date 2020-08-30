using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatController : MonoBehaviour
{
    [SerializeField] private float beatTempo;
    public bool hasStarted;

    private float timer;

    public float BeatTempo
    {
        get { return beatTempo; }
    }
    void Start()
    {
        hasStarted = false;
        beatTempo = (beatTempo / 60f);
    }

    private void Update()
    {
        if (hasStarted)
        {
            
            
            GetComponent<AudioSource>().Play();
            hasStarted = false;
            
        }
    }

}
