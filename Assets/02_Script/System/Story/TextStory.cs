using Class;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextStory : MonoBehaviour
{

    [SerializeField] private TMP_Text tmpText;
    [SerializeField] private Image baseImage;
    [SerializeField] private List<StoryTextBaseClass> stories;

    private StoryTextBaseClass currentStory;
    private bool isTyping;
    private int crtIDX = 0;
    public bool isAble { get; set; } = true;


    private void SetText()
    {

        isTyping = true;
        var obj = currentStory.storyTexts[crtIDX];
        StartCoroutine(SetTextCo(tmpText, obj.storyText, obj.textDuration, obj.apertureEvent, obj.endEvent));

    }

    private void EndText()
    {

        currentStory.endEvent?.Invoke();
        currentStory = null;
        isTyping = false;
        crtIDX = 0;
        tmpText.text = "";
        baseImage.rectTransform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.OutCirc);

    }
    public void StartText(string value)
    {

        if (!isAble) return;


        currentStory = stories.Find(x => x.storyName == value);
        currentStory.startEvent?.Invoke();
        baseImage.rectTransform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutCirc)
            .OnComplete(SetText);

    }

    public void NextText()
    {

        if(!isAble || currentStory == null) return;

        if (isTyping)
        {

            StopAllCoroutines();
            isTyping=false;
            tmpText.text = currentStory.storyTexts[crtIDX].storyText;

        }
        else
        {

            if(crtIDX == currentStory.storyTexts.Count - 1)
            {

                EndText();
                return;

            }
            crtIDX++;
            SetText();

        }

    }


    private IEnumerator SetTextCo(TMP_Text text, string endValue, 
        float showTextTime, UnityEvent apertureEvent, UnityEvent endEvent)
    {

        text.text = "";

        for(int i = 0; i < endValue.Length; i++)
        {

            text.text += endValue[i];
            apertureEvent?.Invoke();
            yield return new WaitForSeconds(showTextTime);

        }

        endEvent?.Invoke();

        isTyping = false;

    }

}
