using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEvent : InstrumentEvent
{
   [SerializeField] Vector3 minimumScale;
   [SerializeField] Vector3 maxScale;
   [SerializeField] Color bigguerCircleColor;
   SpriteRenderer circleReference;
   Color defaultrCircleColor;

   protected override void ActivateEvent()
   {
      circleReference = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
      animator.SetTrigger("activate");
      defaultrCircleColor = circleReference.color;

      eventStarted = true;
        ChildLookAtCamera();
   }



   protected override void CheckEndAnimation()
   {
      if (circleReference != null) circleReference.color = defaultrCircleColor;

      if (!eventStarted) return;
      Transform compare = eventObject.transform.GetChild(0);
      if (compare.localScale.magnitude < minimumScale.magnitude
          && compare.localScale.magnitude > maxScale.magnitude)
      {
         circleReference.color = bigguerCircleColor;
         canDoAction = true;
      }
      if (compare.localScale.magnitude <= maxScale.magnitude)
      {
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
         circleReference.color = defaultrCircleColor;
      }


   }
}
