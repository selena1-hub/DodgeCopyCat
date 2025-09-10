using UnityEngine;

public class PoliceCarAI : MonoBehaviour
{
    private Transform target;
    public float speed = 10f;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    // �ٸ� �ݶ��̴��� �������� �� ȣ��Ǵ� �Լ�
    void OnTriggerEnter(Collider other)
    {
        // ������ ������Ʈ�� "Player" �±׸� �����ٸ�
        if (other.CompareTag("Player"))
        {
            if (gameManager != null)
            {
                gameManager.GameOver(false); // �й� ó��
            }
            // �÷��̾� ������Ʈ�� �ı��Ͽ� ȭ�鿡�� ������� ��
            Destroy(other.gameObject);
        }
    }
}