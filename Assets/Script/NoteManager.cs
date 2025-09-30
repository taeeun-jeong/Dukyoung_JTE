using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0;//노트 생성 주기 설정
    double currentTime = 0d;//현재 시간 저장

    [SerializeField] Transform tfNoteAppear = null;//노트 생성 위치
    [SerializeField] EffectManager theEffect;// 이펙트 매니저
    [SerializeField] ComboManager theCombo;// 콤보 매니저

    TimingManager theTimingManager;// 타이밍 매니저

    private void Start()
    {
        theTimingManager = GetComponent<TimingManager>();// 타이밍 매니저 컴포넌트 가져오기
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;// 현재 시간에 프레임 시간 더하기

        if (currentTime >= 60d / bpm)// 현재 시간이 노트 생성 주기 이상이면
        {
            GameObject t_note = ObjectPool.instance.noteQueue.Dequeue();// 오브젝트 풀에서 노트 하나 꺼내기
            t_note.transform.position = tfNoteAppear.position;// 노트 생성 위치로 이동
            t_note.SetActive(true);// 노트 활성화
            theTimingManager.boxNoteList.Add(t_note);// 타이밍 매니저의 노트 리스트에 추가
            currentTime -= 60d / bpm;// 현재 시간에서 노트 생성 주기 빼기
        }
    }

    private void OnTriggerExit2D(Collider2D collision)// 노트가 판정 구역을 벗어났을 때
    {
        if(collision.CompareTag("Note"))// 노트 태그를 가진 오브젝트와 충돌했을 때
        {
            if (collision.GetComponent<Note>().GetNoteFlag())// 노트가 히트되지 않았을 때
            {
                theEffect.JudgementEffect(4);// 판정 이펙트
                theCombo.ResetCombo();// 콤보 초기화
            }
                

            theTimingManager.boxNoteList.Remove(collision.gameObject);// 타이밍 매니저의 노트 리스트에서 제거

            ObjectPool.instance.noteQueue.Enqueue(collision.gameObject);// 오브젝트 풀에 노트 다시 넣기
            collision.gameObject.SetActive(false);// 노트 비활성화
        }
    }
}
