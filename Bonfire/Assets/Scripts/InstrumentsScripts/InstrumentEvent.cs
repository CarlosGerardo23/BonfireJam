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
   protected bool eventStarted;
   protected bool canDoAction;

   virtual public void StartEvent(float timeToActive)
   {
      eventStarted = true;
      eventObject.SetActive(true);
      StartCoroutine(ActivateEvent());
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
   protected abstract IEnumerator ActivateEvent(float timeToActive = 0.5f);
   virtual protected IEnumerator CheckEndAnimation()
   {

      yield return new WaitForSeconds(animationTime);
      animationOver = true;
      eventStarted = false;
   }


   virtual protected void CheckLifeOfEvent()
   {

      if (!canDoAction && animationOver&&eventStarted)
      {
         if (actionConditionSucces)
            succes.Invoke();
         else
            fail.Invoke();
         StopAllCoroutines();
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
      CheckLifeOfEvent();

   }

   private void ChildLookAtCamera()
   {
      eventObject.transform.LookAt(Camera.main.transform);
   }
}
