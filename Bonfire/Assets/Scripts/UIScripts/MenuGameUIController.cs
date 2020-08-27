using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MenuGameUIController : UIElement
{
    [SerializeField] GameObject menuGame;

    [SerializeField] SoundEvent soundEvent;
    private void Awake()
    {

        menuGame.SetActive(false);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            menuGame.SetActive(true);
            soundEvent.PlayClip();
        }

    }

}
