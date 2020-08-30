using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class PlayerSelection : MonoBehaviour
{
   [SerializeField] GameObject playerCard1;
   [SerializeField] GameObject playerCard2;
   [SerializeField] GameObject playerCard3;
   [SerializeField] GameObject playerCard4;

   public GameObject player1Prefab;
   public GameObject player2Prefab;
   public GameObject player3Prefab;
   public GameObject player4Prefab;

   public GameObject playerImageHolder;
   public GameObject player1RawImage;
   public GameObject player2RawImage;
   public GameObject player3RawImage;
   public GameObject player4RawImage;

   public float magToScale;
   int numberOfPlayersReady;

   bool started;
   bool oneSound;
   bool twoSound;
   bool threeSound;
   bool goSound;

   bool player1Selected;
   bool player2Selected;
   bool player3Selected;
   bool player4Selected;

   private void Awake()
   {
      started = false;
      numberOfPlayersReady = 0;
      player1Selected = false;
     
   }
   private void OnEnable()
   {
      playerImageHolder.SetActive(true);
   }
   // Update is called once per frame
   void Update()
   {

      if (numberOfPlayersReady >= 2)
      {
         transform.Find("ReadyText").GetComponent<Text>().text = numberOfPlayersReady + " Players Ready! \n Press Start to begin!";
         transform.Find("ReadyTextShadow").GetComponent<Text>().text = numberOfPlayersReady + " Players Ready! \n Press Start to begin!";

         if (Input.GetAxis("Start") > 0 && !started)
         {
            var references = Resources.FindObjectsOfTypeAll<InstrumentSequence>();
            foreach (InstrumentSequence r in references)
            {
               r.numberOfEvents = numberOfPlayersReady;
            }
            started = true;
            transform.Find("ReadyText").gameObject.SetActive(false);
            transform.Find("ReadyTextShadow").gameObject.SetActive(false);
            playerCard1.SetActive(false);
            playerCard2.SetActive(false);
            playerCard3.SetActive(false);
            playerCard4.SetActive(false);
            player1RawImage.SetActive(false);
            player2RawImage.SetActive(false);
            player3RawImage.SetActive(false);
            player4RawImage.SetActive(false);
            transform.parent.GetComponent<AudioSource>().Stop();
            transform.Find("One").gameObject.SetActive(true);
            GetComponent<SoundEvent>().PlayClipByIndex(4);
            playerImageHolder.SetActive(false);
         }
      }

      if (Input.GetKeyDown(KeyCode.Joystick1Button0) && !player1Selected)
      {
         numberOfPlayersReady++;
         player1Selected = true;
         Instantiate(player1Prefab, player1Prefab.transform.position, player1Prefab.transform.rotation);
         playerCard1.GetComponent<Animator>().SetBool("activate", true);
         playerCard1.transform.GetChild(0).GetComponent<Image>().enabled = false;
         playerCard1.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Ready!";
         playerCard1.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Ready!";
         GetComponent<SoundEvent>().PlayClipByIndex(2);
         player1RawImage.SetActive(true);

      }
      if (Input.GetKeyDown(KeyCode.Joystick2Button0) && !player2Selected)
      {
         numberOfPlayersReady++;
         player2Selected = true;
         Instantiate(player2Prefab, player2Prefab.transform.position, player2Prefab.transform.rotation);
         playerCard2.GetComponent<Animator>().SetBool("activate", true);
         playerCard2.transform.GetChild(0).GetComponent<Image>().enabled = false;
         playerCard2.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Ready!";
         playerCard2.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Ready!";
         GetComponent<SoundEvent>().PlayClipByIndex(2);
         player2RawImage.SetActive(true);
      }

      if (Input.GetKeyDown(KeyCode.Joystick3Button0) && !player3Selected)
      {
         numberOfPlayersReady++;
         player3Selected = true;
         Instantiate(player3Prefab, player3Prefab.transform.position, player3Prefab.transform.rotation);
         playerCard3.GetComponent<Animator>().SetBool("activate", true);
         playerCard3.transform.GetChild(0).GetComponent<Image>().enabled = false;
         playerCard3.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Ready!";
         playerCard3.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Ready!";
         GetComponent<SoundEvent>().PlayClipByIndex(2);
         player3RawImage.SetActive(true);
      }
      if (Input.GetKeyDown(KeyCode.Joystick4Button0) && !player4Selected)
      {
         numberOfPlayersReady++;
         player4Selected = true;
         Instantiate(player4Prefab, player4Prefab.transform.position, player4Prefab.transform.rotation);
         playerCard4.GetComponent<Animator>().SetBool("activate", true);
         playerCard4.transform.GetChild(0).GetComponent<Image>().enabled = false;
         playerCard4.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Ready!";
         playerCard4.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Ready!";
         GetComponent<SoundEvent>().PlayClipByIndex(2);
         player4RawImage.SetActive(true);
      }


      if (transform.Find("One") != null)
      {
         if (transform.Find("One").GetComponent<RectTransform>().sizeDelta.magnitude >= magToScale && !oneSound)
         {
            oneSound = true;
            GetComponent<SoundEvent>().PlayClipByIndex(4);
            transform.Find("One").gameObject.SetActive(false);
            transform.Find("Two").gameObject.SetActive(true);
         }
      }

      if (transform.Find("Two") != null)
      {
         if (transform.Find("Two").GetComponent<RectTransform>().sizeDelta.magnitude > magToScale && !twoSound)
         {
            twoSound = true;
            GetComponent<SoundEvent>().PlayClipByIndex(4);
            transform.Find("Two").gameObject.SetActive(false);
            transform.Find("Three").gameObject.SetActive(true);
         }
      }

      if (transform.Find("Three") != null)
      {
         if (transform.Find("Three").GetComponent<RectTransform>().sizeDelta.magnitude > magToScale && !threeSound)
         {
            threeSound = true;
            GetComponent<SoundEvent>().PlayClipByIndex(5);
            transform.Find("Three").gameObject.SetActive(false);
            transform.Find("Go").gameObject.SetActive(true);
         }
      }

      if (transform.Find("Go") != null)
      {
         if (transform.Find("Go").GetComponent<RectTransform>().sizeDelta.magnitude > magToScale && !goSound)
         {
            goSound = true;
            FindObjectOfType<BeatController>().hasStarted = true;
            FindObjectOfType<RhythmGameManager>().hasStarted = true;
            transform.Find("Go").gameObject.SetActive(false);
            transform.Find("Cloud").gameObject.SetActive(false);
            transform.parent.GetComponent<UIController>().ChangeByName("GamePlay");
         }
      }


   }
}
