using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : PlayerBehaviorRoot
{

    private readonly int OutLineValueHash = Shader.PropertyToID("_OuterOutlineFade");
    private readonly int OutLineColorHash = Shader.PropertyToID("_OuterOutlineColor");

    [SerializeField] private Transform particlePos;
    [SerializeField] private float zoomInValue;
    [SerializeField] private float lvUpTime = 1f;
    [SerializeField] private float holdMoveSpeed;
    [SerializeField] private float skillCoolDownTile = 2f;

    private PlayerMove playerMove;
    private PlayerJump playerJump;
    private PlayerDash playerDash;
    private PlayerAttack playerAttack;
    private PlayerFlip flip;
    private int currentLV = 1;
    private bool isShowAnime = false;

    public bool skillAble = true;

    protected override void Awake()
    {

        base.Awake();
        playerMove = GetComponent<PlayerMove>();
        flip = GetComponent<PlayerFlip>();
        playerAttack = GetComponent<PlayerAttack>();
        playerJump = GetComponent<PlayerJump>();
        playerDash = GetComponent<PlayerDash>();
        
        AddEvent();

    }

    private void PressEvent()
    {

        if (!skillAble) return;

        isShowAnime = true;
        spriteRenderer.material.SetFloat(OutLineValueHash, 1);
        playerMove.SetMoveSpeed(holdMoveSpeed);

        playerAttack.RemoveEvent();
        playerDash.RemoveEvent();
        playerJump.RemoveEvent();

        animator.SetSkillHoldHash(true);
        animator.SetSkillHoldTriggerHash();

        StartCoroutine(LvUpCo());

    }

    private void UpEvent()
    {

        if (!skillAble || !isShowAnime) return;

        isShowAnime = false;
        animator.ResetLandingTrigger();
        spriteRenderer.material.SetFloat(OutLineValueHash, 0);
        currentLV = 1;
        flip.flipAble = false;

        animator.SetSkillHoldHash(false);

        StopAllCoroutines();
        skillAble = false;

        FAED.InvokeDelay(() => skillAble = true, skillCoolDownTile);

    }

    public void HoldEventEnd()
    {

        flip.flipAble = true;
        playerAttack.AddEvent();
        playerJump.AddEvent();
        playerDash.AddEvent();
        playerMove.SetMoveSpeed(-1);

    }

    public override void AddEvent()
    {

        actionSystem.OnHoldSkillPressEvnet += PressEvent;
        actionSystem.OnHoldSkillKeyUpEvent += UpEvent;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnHoldSkillPressEvnet -= PressEvent;
        actionSystem.OnHoldSkillKeyUpEvent -= UpEvent;

    }

    private IEnumerator LvUpCo()
    {

        while(currentLV <= 3)
        {

            spriteRenderer.material.SetColor(OutLineColorHash, currentLV switch
            {

                1 => Color.white,
                2 => Color.cyan,
                3 => Color.red,
                _ => Color.black

            });

            var obj = FAED.Pop("HoldPTC", particlePos.position, Quaternion.Euler(-90, 0, 0));
            obj.transform.localScale = spriteRenderer.flipX switch
            {

                true => new Vector3(-1, 1, 1),
                false => new Vector3(1, 1, 1)

            };
            var ptc = obj.GetComponent<ParticleSystem>();
            ptc.Play();

            FAED.InvokeDelay(() => FAED.Push(obj), 0.9f);

            yield return new WaitForSeconds(lvUpTime);
            currentLV++;


        }

    }

}
