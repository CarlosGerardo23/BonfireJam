using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeInstrument { TAP, HOLD, MIXED }
public class InstrumentBehaviout : MonoBehaviour
{
   [SerializeField] TapEvent tap;
   [SerializeField] HoldEvent hold;
   [SerializeField] MixedEvent mixed;
   [SerializeField] TypeInstrument instrument;
   bool eventFinish;
   // Start is called before the first frame update
   void Start()
   {
      eventFinish = false;
      switch (instrument)
      {
         case TypeInstrument.TAP:
            StartCoroutine(tap.ActivateEvent());
            break;
         case TypeInstrument.HOLD:
            StartCoroutine(hold.ActivateEvent());
            break;
         case TypeInstrument.MIXED:
            StartCoroutine(mixed.ActivateEvent());
            break;
         default:
            break;
      }
   }

   private void Update()
   {
      if (eventFinish)
         return;
      switch (instrument)
      {
         case TypeInstrument.TAP:
            eventFinish = tap.CanDoAction();
            break;
         case TypeInstrument.HOLD:
            eventFinish = hold.CanDoAction();
            break;
         case TypeInstrument.MIXED:
            eventFinish = mixed.CanDoAction();
            break;
         default:
            break;
      }
   }
}

  
