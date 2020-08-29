using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWay3DCollider : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {

      if (other.tag == "Player")
      {

         if (other.GetComponent<Rigidbody>().velocity.y >= 0)
         {
            Debug.Log("Desactiva");
            transform.GetComponentInChildren<BoxCollider>().enabled = false;
         }
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.tag == "Player")
      {
         transform.GetComponentInChildren<BoxCollider>().enabled = true;

      }
   }
}
