using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEvent : InstrumentEvent
{
   [SerializeField] float minimumTime;

  
   protected override IEnumerator ActivateEvent(float timeToActive = 0.5f)
   {
      yield return new WaitForSeconds(timeToActive);
      
      animator.SetTrigger("activate");
      StartCoroutine(CheckEndAnimation());
      eventStarted = true;
   }

 

   protected override IEnumerator CheckEndAnimation()
   {
      yield return new WaitForSeconds(minimumTime);
      canDoAction = true;
      yield return new WaitForSeconds(animationTime);
      canDoAction = false;
      animationOver = true;

   }

   public override void DoAction()
   {

      if (!animationOver&&eventStarted)
      {
         if (canDoAction)
            actionConditionSucces = true;
         else
            actionConditionSucces = false;

         canDoAction = false;
         animationOver = true;
       
      }


   }
}
