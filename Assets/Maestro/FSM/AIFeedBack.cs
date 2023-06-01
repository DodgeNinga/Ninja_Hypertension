using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFeedBack : MonoBehaviour
{
    SpriteRenderer _sr;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }
    public void ColorChange()
    {
        StartCoroutine(ColorChangeCoroutine());
    }

    IEnumerator ColorChangeCoroutine()
    {
        float hitFx = 0;
        while(hitFx < 1)
        {
            _sr.material.SetColor("_BlackTintColor", new Color(hitFx, hitFx, hitFx));
            hitFx += 0.05f;
            yield return null;
        }
        yield return new WaitForSeconds(0.01f);
        _sr.material.SetColor("_BlackTintColor", new Color(0, 0, 0));
    }
}
