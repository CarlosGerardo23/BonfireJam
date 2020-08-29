using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElement : MonoBehaviour
{
    [HideInInspector] public string uiName;
    [HideInInspector] public bool haveAnimation;
    [HideInInspector] public Animator animator;
    [HideInInspector] public string hideAnimation;
    [HideInInspector] public bool desactivate;
    [HideInInspector] public PlayerControls player;
    public void DesactivateAnimation()
    {
        animator.SetTrigger("Hide");
        StartCoroutine(CheckAnimationFinish());
    }

    IEnumerator CheckAnimationFinish()
    {

        Debug.Log (animator.GetCurrentAnimatorStateInfo(0).IsName(hideAnimation));
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName(hideAnimation) &&
            animator.GetCurrentAnimatorStateInfo(0).length <= 1)
            yield return null;
        yield return new WaitForSeconds(1f);
        transform.gameObject.SetActive(false);
    }

    public virtual void OnEnable()
    {
        player.UIGameplay.Enable();
    }
    public virtual void OnDisable()
    {
        player.UIGameplay.Disable();
    }
}



