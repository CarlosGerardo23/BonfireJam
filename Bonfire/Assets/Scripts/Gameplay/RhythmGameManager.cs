using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmGameManager : MonoBehaviour
{
    [SerializeField] BeatController beat;
    [SerializeField] InstrumentSequence sequence;
    public bool hasStarted = false;

    private void Awake()
    {

        beat.action = sequence.DoOneEvent;
    }

    private void Update()
    {
        if (hasStarted)
        {


            beat.GetComponent<AudioSource>().Play();
            hasStarted = false;
            beat.hasStarted = true;

        }
    }

}
