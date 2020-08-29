using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWay : MonoBehaviour
{
    
    private void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {

            if (other.transform.position.y <= transform.Find("Top").transform.position.y )
            {

                transform.Find("Top").GetComponent<BoxCollider>().enabled = false;
            }
            else if (other.transform.position.y >= transform.Find("Top").transform.position.y + (transform.Find("Top").GetComponent<BoxCollider>().size.y / 2) + 0.5)
            {
                transform.Find("Top").GetComponent<BoxCollider>().enabled = true;
            }
        }
    }



}
