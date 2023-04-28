using Class;
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
    private bool isAble;
    private int crtIDX;


    private void SetText()
    {

        isTyping = true;
        var obj = currentStory.storyTexts[crtIDX];
        StartCoroutine(SetTextCo(tmpText, obj.storyText, obj.textDuration, obj.apertureEvent, obj.endEvent));

    }
    public void StartText(string value)
    {

        if (!isAble) return;

        currentStory = stories.Find(x => x.storyName == value);

        SetText();

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
