using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDebugguer : MonoBehaviour
{
   [SerializeField] RhythmGameManager testManager;

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.J))
      {
         testManager.hasStarted = true;
      }
   }
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
