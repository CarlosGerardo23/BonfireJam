using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.Interactions;

public class MenuGameUIController : UIElement
{
  [SerializeField] SoundEvent soundEvent;
  [SerializeField] UnityEvent menuClose;

  bool isMenuShown;
  Vector2 move;
  bool algo = false;
  public override void Awake()
  {
    base.Awake();
    isMenuShown = false;
    animator = GetComponent<Animator>();

    player.UIGameplay.MoveSelection.performed += ctx => { if (ctx.interaction is PressInteraction) { move = ctx.ReadValue<Vector2>(); } };

    player.UIGameplay.MoveSelection.canceled += ctx => { if (ctx.interaction is PressInteraction) { move = Vector2.zero; } };

  }
  private void Update()
  {

    if (Input.GetKeyDown(KeyCode.M))
    {
      if (!isMenuShown)
      {
        animator.SetTrigger("Show");
        soundEvent.PlayClip();
        isMenuShown = true;
      }
      else
      {
        menuClose.Invoke();
        animator.SetTrigger("Hide");
        soundEvent.PlayClip();
        isMenuShown = false;
      }

    }
    if (move.y < 0)
    {
      if (!algo)
      {
        Debug.Log("Abajo");
        algo = true;
      }

    }
    if (move.y > 0)
    {
      if (algo)
      {
        Debug.Log("Arriba");
        algo = false;
      }

    }


  }

}
