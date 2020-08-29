using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEvent : InstrumentEvent
{
   [SerializeField] float minimumTime;
  public bool actionConditionSucces;

   public override IEnumerator ActivateEvent()
   {
      yield return new WaitForSeconds(.5f);
      eventObject.SetActive(true);
      StartCoroutine(CheckEndAnimation());
      eventStarted = true;
   }

   public override bool CanDoAction()
   {
      if (!eventStarted) return true;

      if (Input.GetKeyDown(KeyCode.A) || animationOver)
      {
         if (actionConditionSucces && !animationOver)
            Debug.Log("Succes");
         else if (!animationOver)
            Debug.Log("Faile");
         return false;
      }
      return true;
   }

   protected override IEnumerator CheckEndAnimation()
   {
      yield return new WaitForSeconds(minimumTime);
      actionConditionSucces = true;
      yield return new WaitForSeconds(animationTime);
      actionConditionSucces = false;
      animationOver = true;

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
}
