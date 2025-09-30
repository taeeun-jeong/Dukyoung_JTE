using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform[] linePositions; // ���� ��ġ �迭 (0: ���� ��, ������: ������ ��)
    public float moveSpeed = 5f;      // �̵� �ӵ�

    private int currentLineIndex;     // ���� ���� �ε���
    private int targetLineIndex;      // ��ǥ ���� �ε���
    private bool isMoving = false;    // �̵� �� ����

    private Animator animator;        // �ִϸ�����

    void Start()
    {
        currentLineIndex = linePositions.Length - 1; // ���� ��ġ (������ ��)
        targetLineIndex = currentLineIndex;
        transform.position = linePositions[currentLineIndex].position;

        animator = GetComponent<Animator>();
        // Running�� �⺻ �����̹Ƿ� ���� Set �ʿ� ����
    }

    void Update()
    {
        HandleInput();

        if (isMoving)
            MoveToTargetLine();
    }

    void HandleInput()
    {
        if (isMoving) return; // �̵� �߿� �¿� �Է� ����

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int nextIndex = currentLineIndex - 1;
            if (nextIndex >= 0)
            {
                targetLineIndex = nextIndex;
                isMoving = true;

                animator.SetTrigger("Left"); // Left �ִϸ��̼� ����
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int nextIndex = currentLineIndex + 1;
            if (nextIndex < linePositions.Length)
            {
                targetLineIndex = nextIndex;
                isMoving = true;

                animator.SetTrigger("Right"); // Right �ִϸ��̼� ����
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetTrigger("Dash"); // Dash �ִϸ��̼� ���� (�����̵�)
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
            // �ִϸ��̼��� �ڵ����� Running���� ���͵�
        }
    }
}
