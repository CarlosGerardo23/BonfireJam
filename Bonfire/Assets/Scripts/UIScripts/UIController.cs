using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    List<UIElement> uiElements = new List<UIElement>();
    [SerializeField] UIElement firstScene;
    [SerializeField] PlayerControls player;
    void Awake()
    {
        player = new PlayerControls();
        for (int i = 0; i < transform.childCount; i++)
        {
            UIElement temp = transform.GetChild(i).GetComponent<UIElement>();
            temp.player = player;
            temp.gameObject.SetActive(false);
            temp.desactivate = true;
            uiElements.Add(temp);
        }
        firstScene.desactivate = false;
        SetElements();
    }

    private void SetElements()
    {
        foreach (var item in uiElements)
        {
            if (item.gameObject.activeSelf)
            {
                if (item.desactivate)
                {
                    if (item.haveAnimation)
                        item.DesactivateAnimation();
                    else
                    {
                        item.desactivate = false;
                        item.gameObject.SetActive(false);
                    }
                }

            }
            else if (!item.desactivate)
            {
                item.gameObject.SetActive(true);
            }

        }

    }

    public void ChangeByName(string name)
    {
        for (int i = 0; i < uiElements.Count; i++)
        {
            if (uiElements[i].name == name)
                uiElements[i].desactivate = false;
            else
                uiElements[i].desactivate = true;
        }
        SetElements();
    }
    public void ActivateElementByName(string name)
    {
        for (int i = 0; i < uiElements.Count; i++)
        {
            if (uiElements[i].uiName == name)
            {
                uiElements[i].desactivate = false;
                SetElements();
                return;
            }
        }
    }
    public void DesactivateElementByName(string name)
    {
        for (int i = 0; i < uiElements.Count; i++)
        {
            if (name == uiElements[i].uiName)
                uiElements[i].desactivate = true;
            SetElements();
        }
    }

    public void DesactivateAll(UIElement exception = null)
    {
        for (int i = 0; i < uiElements.Count; i++)
        {
            if (exception != null && exception == uiElements[i])
            {
                uiElements[i].desactivate = false;
                continue;
            }
            uiElements[i].desactivate = true;
            SetElements();
        }
    }


}
