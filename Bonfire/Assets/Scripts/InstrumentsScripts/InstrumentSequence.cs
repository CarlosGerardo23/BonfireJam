﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentSequence : MonoBehaviour
{
   List<InstrumentEvent> events;
   List<InstrumentEvent> sequence;
   private void Awake()
   {
      events = new List<InstrumentEvent>();
      for (int i = 0; i < transform.childCount; i++)
      {
         events.Add(transform.GetChild(i).gameObject.GetComponent<InstrumentEvent>());
      }
      sequence = new List<InstrumentEvent>(events);
   }
   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.K))
      {
         StartCoroutine(DoSequence());
      }
   }

   private IEnumerator DoSequence()
   {
      if (sequence == null || sequence.Count == 0)
      {
         Debug.LogError("Sequence not initialize");
         yield return null;
      }

      while (sequence.Count > 0)
      {
         int sequenceIndex = Random.Range(0, sequence.Count);
         InstrumentEvent temp = sequence[sequenceIndex];
         sequence.Remove(temp);
         yield return new WaitForSeconds(1f);
         temp.StartEvent();
      }
      sequence = new List<InstrumentEvent>(events);
   }

   public void DoOneEvent()
   {
      if (sequence == null || sequence.Count == 0)
      {
         Debug.LogError("Sequence not initialize");
         return;
      }

      int sequenceIndex = Random.Range(0, sequence.Count);
      InstrumentEvent temp = sequence[sequenceIndex];
      if (temp==null||temp.eventStarted)
         return;
      sequence.Remove(temp);
     
      temp.StartEvent();

      if(sequence.Count<1)
      sequence = new List<InstrumentEvent>(events);
   }
}
