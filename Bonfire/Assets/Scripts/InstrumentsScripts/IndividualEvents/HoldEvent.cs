using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldEvent : InstrumentEvent
{
   public bool isHolding;
   bool eventPass = false;
   public override IEnumerator ActivateEvent()
   {
      yield return new WaitForSeconds(.5f);
      eventObject.SetActive(true);
      eventStarted = true;
   }

   public override bool CanDoAction()
   {
      if (!eventStarted) return true;
      if (Input.GetKeyDown(KeyCode.A))
      {
         isHolding = true;
         animator.SetTrigger("activate");
         if (!eventStarted || animationOver)
            StopAllCoroutines();
         else
            StartCoroutine(CheckEndAnimation());
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

   protected override IEnumerator CheckEndAnimation()
   {
      yield return new WaitForSeconds(animationTime);
      animationOver = true;
      eventStarted = false;
      eventPass = true;
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
}
