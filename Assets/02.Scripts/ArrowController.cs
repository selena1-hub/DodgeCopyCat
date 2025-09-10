using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float arrowSpeed = 15f;
    private Vector3 targetDirection;
    private GameManager gameManager; // GameManager�� �����ϱ� ���� ����

    void Start()
    {
        // GameManager ������Ʈ�� ã�� ��ũ��Ʈ�� ������
        gameManager = FindObjectOfType<GameManager>();
    }

    public void SetTargetDirection(Vector3 direction)
    {
        targetDirection = direction;
    }

    void Update()
    {
        transform.Translate(targetDirection * arrowSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}