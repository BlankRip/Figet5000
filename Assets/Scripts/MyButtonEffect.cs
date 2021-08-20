using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Animator animator;
    bool clicked;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void OnEnable() {
        if(clicked) {
            GoBackToNormal();
            clicked = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        GoOnHover();
    }

    public void OnPointerExit(PointerEventData eventData) {
        GoBackToNormal();
    }

    public void GoOnHover() {
        animator.SetTrigger("nowHover");
    }

    public void GoBackToNormal() {
        animator.SetTrigger("goBack");
    }

    public void OnPointerClick(PointerEventData eventData) {
        //SFx.instance.PlayButtonClick();
        clicked = true;
    }
}
