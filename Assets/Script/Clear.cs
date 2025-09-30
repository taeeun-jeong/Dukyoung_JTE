using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    public AudioSource audioSource;           // ���� ��� ���� ����
    public string clearSceneName = "ClearScene"; // �̵��� �� �̸�

    private bool hasTriggered = false;        // �ߺ� �̵� ����

    void Update()
    {
        // ������ ������ ���� �� �̵����� �ʾҴٸ�
        if (!audioSource.isPlaying && audioSource.time > 0f && !hasTriggered)
        {
            hasTriggered = true;
            SceneManager.LoadScene(clearSceneName);
        }
    }
}
