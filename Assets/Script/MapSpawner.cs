using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    [Header("맵 설정")]
    public GameObject[] patterns;       // 맵 패턴 프리팹
    public int queueSize = 5;           // 유지할 맵 개수
    public float mapSpeed = 5f;         // 맵이 뒤로 움직이는 속도
    public float mapLength = 20f;       // 모든 맵 조각 길이

    [Header("패턴 순서")]
    public int[] patternOrder = { 0, 3, 2, 5, 1, 5 }; // 원하는 순서
    private int orderIndex = 0;

    private Queue<GameObject> mapQueue = new Queue<GameObject>();

    void Start()
    {
        // 처음 맵 큐 채우기
        for (int i = 0; i < queueSize; i++)
        {
            SpawnNewPattern();
        }
    }

    void Update()
    {
        // 모든 맵 뒤로 이동
        foreach (GameObject map in mapQueue)
        {
            if (map != null)
                map.transform.Translate(Vector3.back * mapSpeed * Time.deltaTime);
        }

        // 가장 앞 맵이 화면 뒤로 완전히 나가면 삭제 후 새 맵 생성
        if (mapQueue.Count > 0 && mapQueue.Peek().transform.position.z < -30f) // -30f는 카메라 위치에 맞춰 조정
        {
            GameObject oldMap = mapQueue.Dequeue();
            Destroy(oldMap);

            SpawnNewPattern();
        }
    }

    void SpawnNewPattern()
    {
        int index = patternOrder[orderIndex];

        // 새 맵 스폰 위치 = 큐 마지막 맵 뒤
        Vector3 spawnPos;
        if (mapQueue.Count > 0)
        {
            GameObject lastMap = mapQueue.ToArray()[mapQueue.Count - 1];
            spawnPos = lastMap.transform.position + new Vector3(0, 0, mapLength);
        }
        else
        {
            spawnPos = Vector3.zero; // 처음 스폰
        }

        GameObject newPattern = Instantiate(patterns[index], spawnPos, Quaternion.identity);
        mapQueue.Enqueue(newPattern);

        // 순서 인덱스 증가 (마지막까지 가면 처음으로)
        orderIndex = (orderIndex + 1) % patternOrder.Length;
    }
}
