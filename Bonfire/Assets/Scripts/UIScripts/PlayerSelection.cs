using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerSelection : MonoBehaviour
{
    [SerializeField] GameObject playerCard1;
    [SerializeField] GameObject playerCard2;
    [SerializeField] GameObject playerCard3;
    [SerializeField] GameObject playerCard4;

    [SerializeField] GameObject startGame;

    [SerializeField] UnityEvent playerSelected;
    int currentPalyer = 0;
    // Update is called once per frame
    void Update()
    {
        startGame.SetActive(false);
        CheckCardSelection();
        if (currentPalyer >= 2)
            CanStartGame();
    }

    private void CanStartGame()
    {
        startGame.SetActive(true);
    }

    private void CheckCardSelection()
    {
        bool isPlayerSelecetd = false;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerCard1.GetComponent<Animator>().SetBool("activate", true);
            currentPalyer++;
            isPlayerSelecetd = true;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerCard2.GetComponent<Animator>().SetBool("activate", true);
            currentPalyer++;
            isPlayerSelecetd = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            playerCard3.GetComponent<Animator>().SetBool("activate", true);
            currentPalyer++;
            isPlayerSelecetd = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            playerCard4.GetComponent<Animator>().SetBool("activate", true);
            currentPalyer++;
            isPlayerSelecetd = true;
        }
        if (isPlayerSelecetd)        
            playerSelected.Invoke();
        
    }
}
