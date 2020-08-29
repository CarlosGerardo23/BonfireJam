using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDebugguer : MonoBehaviour
{
   public void SuccesMessage()
   {
      Debug.Log("Succes");
   }

   public void FaileMessage()
   {
      Debug.Log("Fail");
   }

   public void CustomMessage(string message)
   {
      Debug.Log(message);
   }
}
