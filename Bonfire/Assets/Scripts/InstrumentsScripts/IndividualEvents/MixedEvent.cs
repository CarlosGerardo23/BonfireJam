using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixedEvent : InstrumentEvent
{
   TapEvent tap;
   List<HoldEvent> holdEvents;
   bool activateTap;
   public bool succes;
   protected override void ActivateEvent()
   {
    
      foreach (var item in holdEvents)
      {
        // StartCoroutine(item.ActivateEvent());
      }
   }

   public  bool CanDoAction()
   {
      foreach (var item in holdEvents)
      {
         if (!item.isHolding)
            return true;
      }
      if (!activateTap)
      {
        // StartCoroutine(tap.ActivateEvent());
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

   public override void DoAction()
   {
      throw new System.NotImplementedException();
   }

   protected override void CheckEndAnimation()
   {
      throw new System.NotImplementedException();
   }
}
