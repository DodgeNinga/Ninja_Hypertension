using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using FD.Dev;

public class LineEffect : MonoBehaviour
{

    [SerializeField] private float dissolveTime = 1f;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void Show()
    {

        transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360f));

        spriteRenderer.color = Color.white;

        spriteRenderer.DOFade(0, dissolveTime)
            .OnComplete(() => FAED.Push(gameObject));

    }

}
