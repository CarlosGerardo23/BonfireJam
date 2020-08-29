using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWay : MonoBehaviour
{
   [SerializeField] GameObject topCollider;
   [SerializeField] GameObject wayPoint;
   private void Update()
   {

   }
   private void OnTriggerStay(Collider other)
   {

      if (other.tag == "Player")
      {
        
         if (other.transform.position.y <= wayPoint.transform.position.y)
         {

            topCollider.GetComponent<BoxCollider>().enabled = false;
         }
         else //if (other.transform.position.y >= wayPoint.transform.position.y)
         {
            topCollider.GetComponent<BoxCollider>().enabled = true;
         }
      }
   }



}
