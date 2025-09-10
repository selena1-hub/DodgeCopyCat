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
        // ������ٵ��� �ӵ��� newVeclocity �Ҵ�
        rb.linearVelocity = newVelocity;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishZone"))
        {
            if (gameManager != null)
            {
                gameManager.GameOver(true);
            }
        }
    }

    //void FixedUpdate()
    //{
    //    float h = Input.GetAxis("Horizontal");
    //    float v = Input.GetAxis("Vertical");

    //    Vector3 moveDirection = new Vector3(h, 0, v);

    //    // �̵� ������ 0�� �ƴ� ���� �÷��̾��� ������ ȸ��
    //    if (moveDirection != Vector3.zero)
    //    {
    //        // �̵� ������ �ٶ󺸰� �� (Y�ุ ȸ��)
    //        transform.LookAt(transform.position + moveDirection);
    //    }

    //    rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    //}
}