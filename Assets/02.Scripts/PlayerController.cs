using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Rigidbody rb;
    private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // ������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // ���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ���� ����
        float xSpeed = xInput * moveSpeed;
        float zSpeed = zInput * moveSpeed;

        // Vector3 �ӵ��� (xSpeed, 0f, zSpeed)�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        if (newVelocity != Vector3.zero)
        {
            transform.forward = Vector3.Lerp(transform.forward, newVelocity, 0.1f);
        }

        // ������ٵ��� �ӵ��� newVelocity �Ҵ�
        rb.linearVelocity = newVelocity;
    }

    // --- �� �κ��� Update() �Լ� ������ ���;� �մϴ� ---
    void OnTriggerEnter(Collider other)
    {
        // ���� ��ü�� �±װ� "FinishZone"���� Ȯ��
        if (other.CompareTag("FinishZone"))
        {
            if (gameManager != null)
            {
                // ���� �Ŵ����� GameOver �Լ��� ȣ���ϰ� �¸�(true)�� ����
                gameManager.GameOver(true);
            }
        }
    }

    public void Die()
    {
        if (gameManager != null)
        {
            // false�� �Ѱܼ� �÷��̾ '�й�'������ �˸�
            gameManager.GameOver(false);
        }
        // �÷��̾� ������Ʈ�� ��Ȱ��ȭ�ؼ� ȭ�鿡�� ������� ��
        gameObject.SetActive(false);
    }
}