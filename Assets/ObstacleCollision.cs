using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� �ݶ��̴��� ��Ȯ�� CapsuleCollider�� ����
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
