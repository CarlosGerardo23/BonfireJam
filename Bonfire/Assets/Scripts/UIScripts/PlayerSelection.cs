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

    public GameObject player1Prefab;
    public GameObject player2Prefab;

    [SerializeField] GameObject startGame;

    bool player1Selected;
    bool player2Selected;

    private void Awake()
    {
        player1Selected = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && !player1Selected)
        {
            player1Selected = true;
            Instantiate(player1Prefab, player1Prefab.transform.position, player1Prefab.transform.rotation);
            playerCard1.GetComponent<Animator>().SetBool("activate", true);
            GetComponent<SoundEvent>().PlayClipByIndex(2);

        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button0) && !player2Selected)
        {
            player2Selected = true;
            Instantiate(player2Prefab, player2Prefab.transform.position, player2Prefab.transform.rotation);
            playerCard2.GetComponent<Animator>().SetBool("activate", true);
            GetComponent<SoundEvent>().PlayClipByIndex(2);
        }
    }
}
