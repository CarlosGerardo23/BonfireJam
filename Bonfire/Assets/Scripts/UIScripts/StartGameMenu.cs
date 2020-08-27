using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartGameMenu : UIElement
{
    [SerializeField] PlayerControls controls;
    // Start is called before the first frame update
    void Awake()
    {
        controls = new PlayerControls();
        controls.UIGameplay.TestStart.performed += test => StartPressed();
    }

  
   
    void StartPressed()
    {
        Debug.Log("Presione start");
    }
    private void OnEnable()
    {
        controls.UIGameplay.Enable();
    }
    private void OnDisable()
    {
        controls.UIGameplay.Disable();
    }
}
