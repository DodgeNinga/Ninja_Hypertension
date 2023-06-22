using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class PotionBase : MonoBehaviour
{
    TextMeshPro _nameText;
    Animator _animator;
    SpriteRenderer _spriteRenderer;
    [SerializeField] private PotionSO _potionSO;
    GameObject Player;
    protected PlayerHP _pHp;
    private bool _canEat;

    private string _pName;

    private void Awake()
    {
        Player = GameObject.Find("Player");
        _pHp = Player.GetComponent<PlayerHP>();
        _nameText = transform.Find("nameText").GetComponent<TextMeshPro>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _canEat = true;
        _pName = _potionSO.potionName;
        _nameText.SetText(_pName);
        PotionInfo _pInfo = PotionManager.Instance.SetPotionType(_potionSO.potionType);
        _animator.runtimeAnimatorController = _pInfo.animator;
        _spriteRenderer.sprite = _pInfo.sprite;
    }

    protected abstract void PotionEffect();

    private void Update()
    {
        if (_canEat && Vector3.Distance(this.transform.position, Player.transform.position) < 0.3f)
        {
            _canEat = false;
            PotionEffect();
        }
    }
}
