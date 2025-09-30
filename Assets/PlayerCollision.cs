using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    // Ʈ���� �浹 ���� (isTrigger�� üũ�� ���)
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� �ݶ��̴��� CapsuleCollider�� ��쿡�� ���ӿ���
        if (other is CapsuleCollider)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    // �Ϲ� �浹 ���� (isTrigger�� üũ���� ���� ���)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider is CapsuleCollider)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
