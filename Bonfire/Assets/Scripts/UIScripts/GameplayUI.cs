using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUI : UIElement
{
    public override void Awake()
    {
        base.Awake();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(transform.GetChild(0).GetChild(i).name);
            transform.GetChild(0).GetChild(i).GetComponent<Animator>().SetBool("gone", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
