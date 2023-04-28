using Class;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class TextStory : MonoBehaviour
{

    [SerializeField] private List<StoryTextBaseClass> stories;

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

    }

}
