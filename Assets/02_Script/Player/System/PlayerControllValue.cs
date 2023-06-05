using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllValue : MonoBehaviour
{

    public bool isJumpAttack { get; set; } = false;
    public bool isHoldAttack { get; set; } = false;
    public bool isAnySkillAttack { get; set; } = false;

    public void SetIsAnySkillAttack()
    {

        isAnySkillAttack = false;

    }

}
