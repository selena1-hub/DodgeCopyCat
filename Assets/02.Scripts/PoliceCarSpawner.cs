using UnityEngine;

public class PoliceCarSpawner : MonoBehaviour
{
    // ����Ƽ �����Ϳ��� ������ ������ ������
    public GameObject policeCarPrefab;
    // �÷��̾��� ��ġ�� �߰� ������� �����ϱ� ����
    public Transform playerTransform;

    void Start()
    {
        // ���� ���� �� �� �� ���� �������� ����
        SpawnPoliceCar();
    }

    void SpawnPoliceCar()
    {
        // ������ ������ ����
        GameObject newPoliceCar = Instantiate(policeCarPrefab, transform.position, Quaternion.identity);

        // ������ �������� AI ��ũ��Ʈ�� ������ �÷��̾��� ��ġ�� �˷���
        PoliceCarAI policeCarAI = newPoliceCar.GetComponent<PoliceCarAI>();
        if (policeCarAI != null)
        {
            policeCarAI.SetTarget(playerTransform);
        }
    }
}