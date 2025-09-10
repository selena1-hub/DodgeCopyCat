using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �÷��̾��� �̵� �ӵ�
    public float moveSpeed = 5.0f;

    void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� �±װ� "Food"���� Ȯ��
        if (other.CompareTag("Food"))
        {
            // �÷��̾� ũ�� Ű���
            GrowPlayer();
        }
    }

    void Update()
    {
        // Ű���� �Է� �ޱ�
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // �̵� ���� ���� ���
        Vector3 moveDirection = new Vector3(h, 0, v);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    public void GrowPlayer()
    {
        Vector3 currentScale = transform.localScale;
        transform.localScale = currentScale + new Vector3(0.1f, 0.1f, 0.1f);
    }
}