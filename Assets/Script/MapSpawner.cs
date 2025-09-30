using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    [Header("�� ����")]
    public GameObject[] patterns;       // �� ���� ������
    public int queueSize = 5;           // ������ �� ����
    public float mapSpeed = 5f;         // ���� �ڷ� �����̴� �ӵ�
    public float mapLength = 20f;       // ��� �� ���� ����

    [Header("���� ����")]
    public int[] patternOrder = { 0, 3, 2, 5, 1, 5 }; // ���ϴ� ����
    private int orderIndex = 0;

    private Queue<GameObject> mapQueue = new Queue<GameObject>();

    void Start()
    {
        // ó�� �� ť ä���
        for (int i = 0; i < queueSize; i++)
        {
            SpawnNewPattern();
        }
    }

    void Update()
    {
        // ��� �� �ڷ� �̵�
        foreach (GameObject map in mapQueue)
        {
            if (map != null)
                map.transform.Translate(Vector3.back * mapSpeed * Time.deltaTime);
        }

        // ���� �� ���� ȭ�� �ڷ� ������ ������ ���� �� �� �� ����
        if (mapQueue.Count > 0 && mapQueue.Peek().transform.position.z < -30f) // -30f�� ī�޶� ��ġ�� ���� ����
        {
            GameObject oldMap = mapQueue.Dequeue();
            Destroy(oldMap);

            SpawnNewPattern();
        }
    }

    void SpawnNewPattern()
    {
        int index = patternOrder[orderIndex];

        // �� �� ���� ��ġ = ť ������ �� ��
        Vector3 spawnPos;
        if (mapQueue.Count > 0)
        {
            GameObject lastMap = mapQueue.ToArray()[mapQueue.Count - 1];
            spawnPos = lastMap.transform.position + new Vector3(0, 0, mapLength);
        }
        else
        {
            spawnPos = Vector3.zero; // ó�� ����
        }

        GameObject newPattern = Instantiate(patterns[index], spawnPos, Quaternion.identity);
        mapQueue.Enqueue(newPattern);

        // ���� �ε��� ���� (���������� ���� ó������)
        orderIndex = (orderIndex + 1) % patternOrder.Length;
    }
}
