using Class;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class TextStory : MonoBehaviour
{

    [SerializeField] private UnityEvent startTextEvent;
    [SerializeField] private UnityEvent endTextEvent;
    [SerializeField] private Image textBox;
    [SerializeField] private TextMeshProUGUI tmpText;
    [SerializeField] private List<StoryTextClass> storyTexts = new List<StoryTextClass>();

    Text t;

    private int crtIDX = 0;

    public void StartText()
    {

        startTextEvent?.Invoke();

        textBox.rectTransform.DOScale(Vector3.one, 0.4f).SetEase(Ease.OutCirc)
            .OnComplete(SetText);

    }

    public void SetText()
    {

        tmpText

    }

}
