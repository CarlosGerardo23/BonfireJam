using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InstrumentEvent : MonoBehaviour
{
   public float animationTime;
   public bool destroyIfFinish;
   protected GameObject eventObject;
   protected Animator animator;
   public bool animationOver;
   protected bool eventStarted;
   virtual protected void SetValues()
   {

      eventObject = transform.GetChild(0).gameObject;
      eventObject.SetActive(false);
      animator = transform.GetComponent<Animator>();
      animationOver = false;
      eventStarted = false;
   }
   public abstract IEnumerator ActivateEvent();
   virtual protected IEnumerator CheckEndAnimation()
   {

      yield return new WaitForSeconds(animationTime);
      animationOver = true;
      eventStarted = false;
   }
   public abstract bool CanDoAction();

   virtual protected void CheckLifeOfEvent()
   {

      if (!CanDoAction())
      {
         if (destroyIfFinish)
            Destroy(gameObject);
         else
            SetValues();


      }

   }
}
