using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEvent : InstrumentEvent
{
   [SerializeField] Vector3 minimumScale;
   [SerializeField] Vector3 maxScale;
   [SerializeField] Color bigguerCircleColor;
   [SerializeField] GameObject bigguerCircleReference;
   Color defaultBigguerCircleColor;

   protected override void ActivateEvent()
   {
      animator.SetTrigger("activate");
      defaultBigguerCircleColor = bigguerCircleReference.GetComponent<SpriteRenderer>().color;

      eventStarted = true;
   }



   protected override void CheckEndAnimation()
   {
      if (!eventStarted) return;
      Transform compare = eventObject.transform.GetChild(0);
      if (compare.localScale.magnitude < minimumScale.magnitude
          && compare.localScale.magnitude > maxScale.magnitude)
      {
         bigguerCircleReference.GetComponent<SpriteRenderer>().color = bigguerCircleColor;
         canDoAction = true;
      }
      if (compare.localScale.magnitude <= maxScale.magnitude)
      {
         bigguerCircleReference.GetComponent<SpriteRenderer>().color = defaultBigguerCircleColor;
         animationOver = true;
         canDoAction = false;
         compare.localScale = new Vector3(1, 1, 1);
         CheckLifeOfEvent();

      }

   }

   public override void DoAction()
   {

      if (!animationOver && eventStarted)
      {
         if (canDoAction)
            actionConditionSucces = true;
         else
            actionConditionSucces = false;

         canDoAction = false;
         animationOver = true;
         CheckLifeOfEvent();

      }


   }
}
