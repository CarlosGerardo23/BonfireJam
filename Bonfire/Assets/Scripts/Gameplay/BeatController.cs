using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatController : MonoBehaviour
{
   public delegate void BeatAction();

   [SerializeField] private float beatTempo;
   public bool hasStarted;
   private float timer;
   public BeatAction action;
   public float BeatTempo {
      get { return beatTempo; }
   }
   void Start()
   {
      hasStarted = false;
      beatTempo = (beatTempo / 60f);
   }


   private void FixedUpdate()
   {

      if (hasStarted)
      {

         if (timer >= beatTempo)
         {
            action.Invoke();
            timer = 0;
         }


         timer += Time.deltaTime;
      }
   }

}
