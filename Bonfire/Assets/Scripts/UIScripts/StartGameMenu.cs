using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartGameMenu : UIElement
{

    // Start is called before the first frame update
    void Awake()
    {
        player.UIGameplay.TestStart.performed += test => StartPressed();
    }
    void StartPressed()
    {
        Debug.Log("Presione start");
    }

}
