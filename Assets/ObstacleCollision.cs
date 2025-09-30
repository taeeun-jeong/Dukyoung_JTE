using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 콜라이더가 정확히 CapsuleCollider일 때만
        if (collision.collider.GetType() == typeof(CapsuleCollider))
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetType() == typeof(CapsuleCollider))
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
