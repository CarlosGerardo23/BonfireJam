using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatController : MonoBehaviour
{
    [SerializeField] private float beatTempo;
    private bool hasStarted;

    private float timer;

    public float BeatTempo
    {
        get { return beatTempo; }
    }
    void Start()
    {
        hasStarted = false;
        beatTempo = (beatTempo / 60f);
    }

    private void Update()
    {
        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                GetComponent<AudioSource>().Play();
                hasStarted = true;
            }
        }
    }
    private void FixedUpdate()
    {
        
        if (hasStarted)
        {

            if (timer >= beatTempo)
            {
                if (transform.GetChild(0).gameObject.activeInHierarchy)
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(0).gameObject.SetActive(true);
                }
                timer = 0;
            }


            timer += Time.deltaTime;
        }
    }

}
