using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Platform : MonoBehaviour
{
    [SerializeField] GrowthScript growthReference;
    [SerializeField] UnityEvent touchPlataform;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().PlaySound(3);
            if (transform.tag == "scalableObject" && !growthReference.animPlaying)
            {
                growthReference.Grow = true;

            }
            collision.gameObject.GetComponent<PlayerMovement>().IsJumping = false;
            if (touchPlataform != null || touchPlataform.GetPersistentEventCount() > 0)
                touchPlataform.Invoke();
        }
    }
}
