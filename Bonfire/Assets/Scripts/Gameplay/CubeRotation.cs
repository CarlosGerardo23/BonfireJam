using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    [SerializeField] private bool rotate;
    private int faceIndex;

    public bool Rotate
    {
        get { return rotate; }
        set { rotate = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        faceIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (faceIndex > 3)
        {
            faceIndex = 0;
        }

        if (rotate)
        {
            GetComponent<SoundEvent>().PlayClip();
            faceIndex++;
            rotate = false;
            GetComponent<Animator>().SetTrigger("rotate");
            StartCoroutine(DropBoys());
        }

        if (faceIndex == 0)
        {
            for (int i = 0; i < transform.Find("Mic").childCount; i++)
            {
                transform.Find("Mic").transform.GetChild(i).gameObject.SetActive(false);
            }
            for (int i = 0; i < transform.Find("PianoLogic").childCount; i++)
            {
                transform.Find("PianoLogic").transform.GetChild(i).gameObject.SetActive(true);
            }
            transform.Find("DrumsLogic").tag = "floor";
            transform.Find("Mic").tag = "wall";
            transform.Find("Mic").tag = "wall";
            transform.Find("Mic").tag = "wall";
        }
        else if (faceIndex == 1)
        {
            for (int i = 0; i < transform.Find("DrumsLogic").childCount; i++)
            {
                transform.Find("DrumsLogic").transform.GetChild(i).gameObject.SetActive(false);
            }
            for (int i = 0; i < transform.Find("Mic").childCount; i++)
            {
                transform.Find("Mic").transform.GetChild(i).gameObject.SetActive(true);
            }
            transform.Find("DrumsLogic").tag = "wall";
            transform.Find("Mic").tag = "wall";
            transform.Find("Mic").tag = "floor";
            transform.Find("Mic").tag = "wall";
        }
        else if (faceIndex == 2)
        {
            for (int i = 0; i < transform.Find("PianoLogic").childCount; i++)
            {
                transform.Find("PianoLogic").transform.GetChild(i).gameObject.SetActive(false);
            }
            for (int i = 0; i < transform.Find("Mic").childCount; i++)
            {
                transform.Find("Mic").transform.GetChild(i).gameObject.SetActive(true);
            }
            transform.Find("DrumsLogic").tag = "wall";
            transform.Find("Mic").tag = "floor";
            transform.Find("Mic").tag = "wall";
            transform.Find("Mic").tag = "wall";
        }
        else if (faceIndex == 3)
        {
            for (int i = 0; i < transform.Find("Mic").childCount; i++)
            {
                transform.Find("Mic").transform.GetChild(i).gameObject.SetActive(false);
            }
            for (int i = 0; i < transform.Find("DrumsLogic").childCount; i++)
            {
                transform.Find("DrumsLogic").transform.GetChild(i).gameObject.SetActive(true);
            }
            transform.Find("DrumsLogic").tag = "wall";
            transform.Find("Mic").tag = "wall";
            transform.Find("Mic").tag = "wall";
            transform.Find("Mic").tag = "floor";
        }

    }

    IEnumerator DropBoys()
    {
        yield return new WaitForSeconds(.5f);
        if (faceIndex == 1)
        {
            FindObjectOfType<RhythmGameManager>().sequence = GameObject.Find("PianoLogic").GetComponent<InstrumentSequence>();
        }
        FindObjectOfType<RhythmGameManager>().hasStarted = true;
        FindObjectOfType<RhythmGameManager>().AskForEvent();
        FindObjectOfType<TransitionCube>().Drop = true;
    }


}
