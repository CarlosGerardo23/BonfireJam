using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public int score;
    bool rotated;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rotated = false;
        score = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<BeatController>().hasStarted)
        {
            if (score <= 0 || score >= 15)
            {
                FindObjectOfType<BeatController>().hasStarted = false;
                FindObjectOfType<RhythmGameManager>().hasStarted = false;
                FindObjectOfType<BeatController>().GetComponent<AudioSource>().Stop();
                
                var players = Resources.FindObjectsOfTypeAll<PlayerMovement>();
                foreach (PlayerMovement p in players)
                {
                    p.gameFinished = true;
                }

                if (score <= 0)
                {
                    FindObjectOfType<UIController>().ChangeByName("LostScreen");
                }
                else
                {
                    FindObjectOfType<UIController>().ChangeByName("WonScreen");
                }
            }

            if (score > 10 && !rotated)
            {
                rotated = true;
                FindObjectOfType<TransitionCube>().IsTransitioning = true;
            }

        }
    }

    public void AddScore()
    {
        
        GetComponent<SoundEvent>().PlayClipByIndex(0);
        score++;
        FindObjectOfType<GameplayUI>().transform.GetChild(0).transform.GetChild(score - 1).GetComponent<Animator>().SetBool("gone", false);
    }

    public void SubtractScore()
    {
        GetComponent<SoundEvent>().PlayClipByIndex(1);
        score--;
        FindObjectOfType<GameplayUI>().transform.GetChild(0).transform.GetChild(score).GetComponent<Animator>().SetBool("gone", true);
    }
}
