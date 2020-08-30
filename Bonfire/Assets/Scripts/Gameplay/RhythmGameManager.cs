using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmGameManager : MonoBehaviour
{
   [SerializeField] BeatController beat;
   [SerializeField] InstrumentSequence sequence;
   bool hasStarted=false;

   private void Awake()
   {
      //beat.action = sequence.DoOneEvent;
   }

   private void Update()
   {
      if (!hasStarted)
      {
         if (Input.anyKeyDown)
         {
            beat.GetComponent<AudioSource>().Play();
            hasStarted = true;
            beat.hasStarted = true;
         }
      }
   }

}
