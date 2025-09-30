using UnityEngine;

public class DestoyObj : MonoBehaviour
{
    public BoxCollider playerCollider; // �÷��̾��� BoxCollider
    public string targetTag = "Destructible"; // �ı� ��� �±�

    void Update()
    {
        // �� Ű �Ǵ� W Ű �Է� ����
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // �÷��̾� �ݶ��̴� ���� ���� ��� �ݶ��̴� ��������
            Collider[] hits = Physics.OverlapBox(
                playerCollider.bounds.center,
                playerCollider.bounds.extents,
                Quaternion.identity);

            // �ش� �±׸� ���� ������Ʈ�� �ı�
            foreach (Collider hit in hits)
            {
                if (hit.CompareTag(targetTag))
                {
                    Destroy(hit.gameObject);
                }
            }
        }
    }

}
