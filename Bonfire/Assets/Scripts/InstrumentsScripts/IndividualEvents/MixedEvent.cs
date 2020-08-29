using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixedEvent : InstrumentEvent
{
   TapEvent tap;
   List<HoldEvent> holdEvents;
   bool activateTap;
   public bool succes;
   public override IEnumerator ActivateEvent()
   {
      yield return new WaitForSeconds(.5f);
      foreach (var item in holdEvents)
      {
         StartCoroutine(item.ActivateEvent());
      }
   }

   public override bool CanDoAction()
   {
      foreach (var item in holdEvents)
      {
         if (!item.isHolding)
            return true;
      }
      if (!activateTap)
      {
         StartCoroutine(tap.ActivateEvent());
         activateTap = true;
      }
      if (tap.animationOver)
      {

         if (tap.actionConditionSucces)
         {
            succes = true;
            return true;
         }
         else
         {
            return false;
         }
      }

      return true;

   }

   // Start is called before the first frame update
   void Awake()
   {
      SetValues();
   }

   // Update is called once per frame
   void Update()
   {
      CheckLifeOfEvent();
   }

   protected override void SetValues()
   {
      activateTap = false;
      base.SetValues();
      holdEvents = new List<HoldEvent>();
      for (int i = 0; i < transform.childCount; i++)
      {
         if (transform.GetChild(i).gameObject.GetComponent<TapEvent>() != null)
         {
            tap = transform.GetChild(i).gameObject.GetComponent<TapEvent>();
         }
         if (transform.GetChild(i).gameObject.GetComponent<HoldEvent>() != null)
         {
            holdEvents.Add(transform.GetChild(i).gameObject.GetComponent<HoldEvent>());
         }
      }
   }
}
