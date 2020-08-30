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
        base.Awake();
    }

    public void OnStart(InputAction.CallbackContext value)
    {
        
            if (value.performed)
            {
                StartPressed();
            }
    }
    void StartPressed()
    {

        FindObjectOfType<CinemachineVirtualCamera>().GetComponent<Animator>().SetTrigger("Move");
        GetComponent<PlayerInput>().enabled = false;
    }

}
