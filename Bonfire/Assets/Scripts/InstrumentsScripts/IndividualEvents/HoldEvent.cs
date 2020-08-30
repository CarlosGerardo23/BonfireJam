using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldEvent : InstrumentEvent
{
   public bool isHolding;
   bool eventPass = false;
   protected override void ActivateEvent()
   {
      eventObject.SetActive(true);
      eventStarted = true;
   }

   public  bool CanDoAction()
   {
      if (!eventStarted) return true;
      if (Input.GetKeyDown(KeyCode.A))
      {
         isHolding = true;
         animator.SetTrigger("activate");
         if (!eventStarted || animationOver)
            StopAllCoroutines();
         else
            
         return true;
      }
      if (Input.GetKeyUp(KeyCode.A))
      {
         isHolding = false;
         StopAllCoroutines();
         eventPass = false;
         return eventPass;
      }
      return true;
   }

   protected override void CheckEndAnimation()
   {
     
      animationOver = true;
      eventStarted = false;
      eventPass = true;
   }
   // Start is called before the first frame update


   // Update is called once per frame
   void Update()
   {
      CheckLifeOfEvent();
   }

   protected override void CheckLifeOfEvent()
   {
      if (animationOver)
      {
         if (eventPass)
            Debug.Log("Succes");
         else
            Debug.Log("Failde");
      }

      base.CheckLifeOfEvent();
   }

   public override void DoAction()
   {
      throw new System.NotImplementedException();
   }
}
