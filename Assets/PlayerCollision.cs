using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    // 트리거 충돌 감지 (isTrigger가 체크된 경우)
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 콜라이더가 CapsuleCollider일 경우에만 게임오버
        if (other is CapsuleCollider)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    // 일반 충돌 감지 (isTrigger가 체크되지 않은 경우)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider is CapsuleCollider)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
