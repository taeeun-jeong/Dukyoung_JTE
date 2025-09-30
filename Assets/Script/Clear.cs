using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    public AudioSource audioSource;           // 현재 재생 중인 음악
    public string clearSceneName = "ClearScene"; // 이동할 씬 이름

    private bool hasTriggered = false;        // 중복 이동 방지

    void Update()
    {
        // 음악이 끝났고 아직 씬 이동하지 않았다면
        if (!audioSource.isPlaying && audioSource.time > 0f && !hasTriggered)
        {
            hasTriggered = true;
            SceneManager.LoadScene(clearSceneName);
        }
    }
}
