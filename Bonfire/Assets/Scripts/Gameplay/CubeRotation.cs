using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    [SerializeField]private bool rotate;
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
            for (int i = 0; i < transform.Find("Flute").childCount; i++)
            {
                transform.Find("Flute").transform.GetChild(i).gameObject.SetActive(true);
            }
            transform.Find("Drums").tag = "floor";
            transform.Find("Piano").tag = "wall";
            transform.Find("Flute").tag = "wall";
            transform.Find("Mic").tag = "wall";
        }
        else if (faceIndex == 1)
        {
            for (int i = 0; i < transform.Find("Drums").childCount; i++)
            {
                transform.Find("Drums").transform.GetChild(i).gameObject.SetActive(false);
            }
            for (int i = 0; i < transform.Find("Piano").childCount; i++)
            {
                transform.Find("Piano").transform.GetChild(i).gameObject.SetActive(true);
            }
            transform.Find("Drums").tag = "wall";
            transform.Find("Piano").tag = "wall";
            transform.Find("Flute").tag = "floor";
            transform.Find("Mic").tag = "wall";
        }
        else if (faceIndex == 2)
        {
            for (int i = 0; i < transform.Find("Flute").childCount; i++)
            {
                transform.Find("Flute").transform.GetChild(i).gameObject.SetActive(false);
            }
            for (int i = 0; i < transform.Find("Mic").childCount; i++)
            {
                transform.Find("Mic").transform.GetChild(i).gameObject.SetActive(true);
            }
            transform.Find("Drums").tag = "wall";
            transform.Find("Piano").tag = "floor";
            transform.Find("Flute").tag = "wall";
            transform.Find("Mic").tag = "wall";
        }
        else if (faceIndex == 3)
        {
            for (int i = 0; i < transform.Find("Piano").childCount; i++)
            {
                transform.Find("Piano").transform.GetChild(i).gameObject.SetActive(false);
            }
            for (int i = 0; i < transform.Find("Drums").childCount; i++)
            {
                transform.Find("Drums").transform.GetChild(i).gameObject.SetActive(true);
            }
            transform.Find("Drums").tag = "wall";
            transform.Find("Piano").tag = "wall";
            transform.Find("Flute").tag = "wall";
            transform.Find("Mic").tag = "floor";
        }

    }

    IEnumerator DropBoys()
    {
        yield return new WaitForSeconds(.5f);
        FindObjectOfType<TransitionCube>().Drop = true;
    }

   
}
