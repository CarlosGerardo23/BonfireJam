using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartGameMenu : UIElement
{
  public int index;
  public bool isPressed=false;

  // Start is called before the first frame update
  public override void Awake()
  {
    base.Awake();
    player.UIGameplay.TestStart.performed += test => StartPressed();
  }
  void StartPressed()
  {
    
    Debug.Log("Presione start: " + index.ToString());
  }

}
