using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform[] linePositions; // 라인 위치 배열 (0: 왼쪽 끝, 마지막: 오른쪽 끝)
    public float moveSpeed = 5f;      // 이동 속도

    private int currentLineIndex;     // 현재 라인 인덱스
    private int targetLineIndex;      // 목표 라인 인덱스
    private bool isMoving = false;    // 이동 중 여부

    private Animator animator;        // 애니메이터

    void Start()
    {
        currentLineIndex = linePositions.Length - 1; // 시작 위치 (오른쪽 끝)
        targetLineIndex = currentLineIndex;
        transform.position = linePositions[currentLineIndex].position;

        animator = GetComponent<Animator>();
        // Running은 기본 상태이므로 별도 Set 필요 없음
    }

    void Update()
    {
        HandleInput();

        if (isMoving)
            MoveToTargetLine();
    }

    void HandleInput()
    {
        if (isMoving) return; // 이동 중엔 좌우 입력 무시

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int nextIndex = currentLineIndex - 1;
            if (nextIndex >= 0)
            {
                targetLineIndex = nextIndex;
                isMoving = true;

                animator.SetTrigger("Left"); // Left 애니메이션 실행
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int nextIndex = currentLineIndex + 1;
            if (nextIndex < linePositions.Length)
            {
                targetLineIndex = nextIndex;
                isMoving = true;

                animator.SetTrigger("Right"); // Right 애니메이션 실행
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetTrigger("Dash"); // Dash 애니메이션 실행 (슬라이딩)
        }
    }

    void MoveToTargetLine()
    {
        Vector3 targetPos = linePositions[targetLineIndex].position;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) < 0.01f)
        {
            transform.position = targetPos;
            currentLineIndex = targetLineIndex;
            isMoving = false;
            // 애니메이션은 자동으로 Running으로 복귀됨
        }
    }
}
