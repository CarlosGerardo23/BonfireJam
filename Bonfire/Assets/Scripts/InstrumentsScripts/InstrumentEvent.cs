using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class InstrumentEvent : MonoBehaviour
{
   public float animationTime;

   public bool actionConditionSucces;
   public UnityEvent succes;
   public UnityEvent fail;
   protected GameObject eventObject;
   protected Animator animator;
   public bool animationOver;
   public bool eventStarted;
   protected bool canDoAction;

   virtual public void StartEvent()
   {
      eventStarted = true;
      eventObject.SetActive(true);
      ActivateEvent();
   }
   virtual protected void SetValues()
   {
      eventObject = transform.GetChild(0).gameObject;
      ChildLookAtCamera();
      eventObject.SetActive(false);
      animator = transform.GetComponent<Animator>();
      animationOver = false;
      eventStarted = false;
   }
   protected abstract void ActivateEvent();
   protected abstract void CheckEndAnimation();



   virtual protected void CheckLifeOfEvent()
   {

      if (!canDoAction && animationOver && eventStarted)
      {
         if (actionConditionSucces)
            succes.Invoke();
         else
            fail.Invoke();

         SetValues();
         eventObject.SetActive(false);
         eventStarted = false;

      }
   }
   virtual public void Awake()
   {
      SetValues();
   }

   public abstract void DoAction();

   private void Update()
   {
      CheckEndAnimation();

   }

   private void ChildLookAtCamera()
   {
      eventObject.transform.LookAt(Camera.main.transform);
   }
}
