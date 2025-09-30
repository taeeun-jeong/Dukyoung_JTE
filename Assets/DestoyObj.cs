using UnityEngine;

public class DestoyObj : MonoBehaviour
{
    public BoxCollider playerCollider; // 플레이어의 BoxCollider
    public string targetTag = "Destructible"; // 파괴 대상 태그

    void Update()
    {
        // ↑ 키 또는 W 키 입력 감지
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // 플레이어 콜라이더 범위 내의 모든 콜라이더 가져오기
            Collider[] hits = Physics.OverlapBox(
                playerCollider.bounds.center,
                playerCollider.bounds.extents,
                Quaternion.identity);

            // 해당 태그를 가진 오브젝트만 파괴
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
