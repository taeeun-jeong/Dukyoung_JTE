using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();//화면에 떠있는 노트 리스트

    [SerializeField] Transform Center = null;//판정 기준 위치
    [SerializeField] RectTransform[] timingRect = null;//판정 박스들
    Vector2[] timingBoxs = null;//판정 박스들의 x좌표 범위
    [SerializeField] private EffectManager theEffect;// 이펙트 매니저
    [SerializeField] private ScoreManager theScore;// 점수 매니저
    [SerializeField] private ComboManager theCombo;// 콤보 매니저
    void Start()
    {

        timingBoxs = new Vector2[timingRect.Length];//판정 박스 개수만큼 배열 생성

        for (int i = 0; i < timingRect.Length; i++)//판정 박스 개수만큼 반복
        {
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2,//판정 박스의 x좌표 범위 설정
                Center.localPosition.x + timingRect[i].rect.width / 2);//판정 박스의 x좌표 범위 설정
        }
    }

    public void CheckTiming()//노트 판정
    {
        for (int i = 0; i < boxNoteList.Count; i++)//화면에 떠있는 노트 개수만큼 반복
        {
            float t_notePosX = boxNoteList[i].transform.localPosition.x;//노트의 x좌표

            for (int x = 0; x < timingBoxs.Length; x++)//판정 박스 개수만큼 반복
            {
                if (timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y)
                {
                    boxNoteList[i].GetComponent<Note>().HideNote();//노트 이미지 숨기기
                    if (x < timingBoxs.Length - 1)
                        theEffect.NoteHitEffect();//노트 히트 이펙트
                    boxNoteList.RemoveAt(i);//노트 삭제
                    theEffect.JudgementEffect(x);//판정 이펙트

                    theScore.IncreaseScore(x);//점수 증가
                    return;
                }
            }
        }
        theCombo.ResetCombo(); //미스뜨면 콤보 초기화
        theEffect.JudgementEffect(timingBoxs.Length);
    }
}
