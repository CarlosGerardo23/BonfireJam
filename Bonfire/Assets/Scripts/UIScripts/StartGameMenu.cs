using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.InputSystem;

public class StartGameMenu : UIElement
{
    public GameObject prefab;
    public int index;
    public bool isPressed = false;

    // Start is called before the first frame update
    public override void Awake()
    {
        transform.parent.GetComponent<SoundEvent>().PlayClip();
        base.Awake();
    }

    private void Update()
    {
        OnStart();
    }

    public void OnStart()
    {

        if (Input.GetAxis("Start") > 0 && !isPressed)
        {
            GetComponent<SoundEvent>().PlayOnDisable(3);
            isPressed = true;
            StartPressed();
        }
    }
    void StartPressed()
    {
        
        FindObjectOfType<CinemachineVirtualCamera>().GetComponent<Animator>().SetTrigger("Move");
        transform.parent.GetComponent<UIController>().ChangeByName("PlayerSelection");
    }

}
