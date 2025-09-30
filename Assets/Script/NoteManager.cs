using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0;//��Ʈ ���� �ֱ� ����
    double currentTime = 0d;//���� �ð� ����

    [SerializeField] Transform tfNoteAppear = null;//��Ʈ ���� ��ġ
    [SerializeField] EffectManager theEffect;// ����Ʈ �Ŵ���
    [SerializeField] ComboManager theCombo;// �޺� �Ŵ���

    TimingManager theTimingManager;// Ÿ�̹� �Ŵ���

    private void Start()
    {
        theTimingManager = GetComponent<TimingManager>();// Ÿ�̹� �Ŵ��� ������Ʈ ��������
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;// ���� �ð��� ������ �ð� ���ϱ�

        if (currentTime >= 60d / bpm)// ���� �ð��� ��Ʈ ���� �ֱ� �̻��̸�
        {
            GameObject t_note = ObjectPool.instance.noteQueue.Dequeue();// ������Ʈ Ǯ���� ��Ʈ �ϳ� ������
            t_note.transform.position = tfNoteAppear.position;// ��Ʈ ���� ��ġ�� �̵�
            t_note.SetActive(true);// ��Ʈ Ȱ��ȭ
            theTimingManager.boxNoteList.Add(t_note);// Ÿ�̹� �Ŵ����� ��Ʈ ����Ʈ�� �߰�
            currentTime -= 60d / bpm;// ���� �ð����� ��Ʈ ���� �ֱ� ����
        }
    }

    private void OnTriggerExit2D(Collider2D collision)// ��Ʈ�� ���� ������ ����� ��
    {
        if(collision.CompareTag("Note"))// ��Ʈ �±׸� ���� ������Ʈ�� �浹���� ��
        {
            if (collision.GetComponent<Note>().GetNoteFlag())// ��Ʈ�� ��Ʈ���� �ʾ��� ��
            {
                theEffect.JudgementEffect(4);// ���� ����Ʈ
                theCombo.ResetCombo();// �޺� �ʱ�ȭ
            }
                

            theTimingManager.boxNoteList.Remove(collision.gameObject);// Ÿ�̹� �Ŵ����� ��Ʈ ����Ʈ���� ����

            ObjectPool.instance.noteQueue.Enqueue(collision.gameObject);// ������Ʈ Ǯ�� ��Ʈ �ٽ� �ֱ�
            collision.gameObject.SetActive(false);// ��Ʈ ��Ȱ��ȭ
        }
    }
}
