using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthScript : MonoBehaviour
{
    private bool grow;
    public bool animPlaying;

    public bool Grow
    {
        get { return grow; }
        set { grow = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (grow)
        {
            grow = false;
            animPlaying = true;
            GetComponent<Animator>().SetTrigger("grow");
            StartCoroutine(isAnimOver());
        }
    }

    IEnumerator isAnimOver()
    {
        yield return new WaitForSeconds(.5f);
        animPlaying = false;
    }
}
