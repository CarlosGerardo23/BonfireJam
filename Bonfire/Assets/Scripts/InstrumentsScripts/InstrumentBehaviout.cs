using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeInstrument { TAP, HOLD, MIXED }
public class InstrumentBehaviout : MonoBehaviour
{
   [SerializeField] TypeInstrument instrument;
   List<GameObject> poitnsOfInterest;
   [SerializeField] Sprite bigCircle;
   [SerializeField] Sprite smallCircle;

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

   }

   public void ActionEventOfInterest()
   {
      switch (instrument)
      {
         case TypeInstrument.TAP:
            break;
         case TypeInstrument.HOLD:
            break;
         case TypeInstrument.MIXED:
            break;
         default:
            break;
      }
   }

   void TapEvent()
   {

   }
   void HoldEvent()
   {

   }
   void MixedEvent()
   {

   }
}
