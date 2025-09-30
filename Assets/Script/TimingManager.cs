using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();//ȭ�鿡 ���ִ� ��Ʈ ����Ʈ

    [SerializeField] Transform Center = null;//���� ���� ��ġ
    [SerializeField] RectTransform[] timingRect = null;//���� �ڽ���
    Vector2[] timingBoxs = null;//���� �ڽ����� x��ǥ ����
    [SerializeField] private EffectManager theEffect;// ����Ʈ �Ŵ���
    [SerializeField] private ScoreManager theScore;// ���� �Ŵ���
    [SerializeField] private ComboManager theCombo;// �޺� �Ŵ���
    void Start()
    {

        timingBoxs = new Vector2[timingRect.Length];//���� �ڽ� ������ŭ �迭 ����

        for (int i = 0; i < timingRect.Length; i++)//���� �ڽ� ������ŭ �ݺ�
        {
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2,//���� �ڽ��� x��ǥ ���� ����
                Center.localPosition.x + timingRect[i].rect.width / 2);//���� �ڽ��� x��ǥ ���� ����
        }
    }

    public void CheckTiming()//��Ʈ ����
    {
        for (int i = 0; i < boxNoteList.Count; i++)//ȭ�鿡 ���ִ� ��Ʈ ������ŭ �ݺ�
        {
            float t_notePosX = boxNoteList[i].transform.localPosition.x;//��Ʈ�� x��ǥ

            for (int x = 0; x < timingBoxs.Length; x++)//���� �ڽ� ������ŭ �ݺ�
            {
                if (timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y)
                {
                    boxNoteList[i].GetComponent<Note>().HideNote();//��Ʈ �̹��� �����
                    if (x < timingBoxs.Length - 1)
                        theEffect.NoteHitEffect();//��Ʈ ��Ʈ ����Ʈ
                    boxNoteList.RemoveAt(i);//��Ʈ ����
                    theEffect.JudgementEffect(x);//���� ����Ʈ

                    theScore.IncreaseScore(x);//���� ����
                    return;
                }
            }
        }
        theCombo.ResetCombo(); //�̽��߸� �޺� �ʱ�ȭ
        theEffect.JudgementEffect(timingBoxs.Length);
    }
}
