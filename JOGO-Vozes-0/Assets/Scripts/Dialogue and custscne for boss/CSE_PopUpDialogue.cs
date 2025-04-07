using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CSE_PopUpDialogue : CutsceneElementBase
{
    [SerializeField] private TMP_Text popUpText;
    [TextArea]
    [SerializeField] private string dialogue;
    [SerializeField] private textPosition textPosition;

    [SerializeField] Animator anim;

    private bool isTextActive;
    public override void Execute()
    {
        SetTextPosition();

        anim.Play("popupfaidin2");
        isTextActive = true;
       popUpText.text = dialogue;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Intereact") && isTextActive)
            anim.Play("popupfadeout2");
    }


    public void SetTextPosition()
    {
        RectTransform rectTransform = popUpText.rectTransform;

        switch (textPosition)
        {
            case textPosition.top:
                rectTransform.anchoredPosition = new Vector2(0, 425);
                break;
                case textPosition.middle:
                rectTransform.anchoredPosition = new Vector2(0, 0);
                break;
            case textPosition.bottom:
                rectTransform.anchoredPosition = new Vector2(0, -425);
                break;
        }

        

        

        rectTransform.anchoredPosition = new Vector2(0, -425);
    }


}
public enum textPosition
{
    top,
    middle,
    bottom
}