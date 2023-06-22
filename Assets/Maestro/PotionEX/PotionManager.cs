using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PotionInfo
{
    public AnimatorOverrideController animator;
    public Sprite sprite;
}

public class PotionManager : MonoBehaviour
{
    public static PotionManager Instance;
    [SerializeField] private List<PotionInfo> _pInfoList = new List<PotionInfo>();

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("!!!");
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public PotionInfo SetPotionType(PotionType type)
    {
        PotionInfo _pInfo = _pInfoList[(int)type];
        return _pInfo;
    }
}
