using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectManager : MonoBehaviour
{
    [SerializeField] Animator HitAnimator = null;
    string hit = "Hit";

    [SerializeField] Animator judgeAnimator = null;
    [SerializeField] UnityEngine.UI.Image judgementImage = null;
    [SerializeField] Sprite[] judgementSprite = null;

    public void JudgementEffect(int p_num)
    {
        judgementImage.sprite = judgementSprite[p_num];
        judgeAnimator.SetTrigger(hit);
    }

    public void NoteHitEffect()
    {
        HitAnimator.SetTrigger(hit);
    }
}
