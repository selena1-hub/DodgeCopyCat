using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrowPrefab; // ȭ�� ������ (Inspector���� ����)
    public Transform playerTransform; // �÷��̾��� ��ġ (Inspector���� ����)
    public float spawnInterval = 2.0f; // ȭ�� ���� ���� (��)

    void Start()
    {
        // spawnInterval �������� SpawnArrow �Լ��� �ݺ� ȣ��
        InvokeRepeating("SpawnArrow", 1f, spawnInterval);
    }

    void SpawnArrow()
    {
        // �÷��̾��� ���� ��ġ
        Vector3 targetPosition = playerTransform.position;
        // ȭ���� ���ƿ� ���� ���� ���
        Vector3 direction = (targetPosition - transform.position).normalized;

        // ȭ�� ������ ����
        GameObject newArrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);

        // ȭ���� ������ �÷��̾� ������ ȸ��
        newArrow.transform.LookAt(targetPosition);

        // ArrowController ��ũ��Ʈ�� ��ǥ ���� ���� �Լ� ȣ��
        newArrow.GetComponent<ArrowController>().SetTargetDirection(direction);
    }
}