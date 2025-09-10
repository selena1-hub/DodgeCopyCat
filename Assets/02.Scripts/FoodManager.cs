using UnityEngine;

public class FoodManager : MonoBehaviour
{
    // ����Ƽ �����Ϳ��� ������ ������
    public GameObject foodPrefab;
    public Transform playerTransform;

    // ���� ũ�⿡ ���缭 ��Ȯ�ϰ� ������ ��ǥ
    // (50x50 ũ���� ���� �������� ����)
    private Vector3[] spawnPositions = new Vector3[]
    {
        // �߾� ������ �� �𼭸�
        new Vector3(15, 0.5f, 15),
        new Vector3(-15, 0.5f, 15),
        new Vector3(15, 0.5f, -15),
        new Vector3(-15, 0.5f, -15),
        // �߾� ������ �� �����ڸ�
        new Vector3(0, 0.5f, 15),
        new Vector3(0, 0.5f, -15),
        new Vector3(15, 0.5f, 0),
        new Vector3(-15, 0.5f, 0)
    };

    void Start()
    {
        // ���� ���� �� ���� �ϳ� ����
        SpawnFood();
    }

    public void SpawnFood()
    {
        // �������� ��ġ ����
        Vector3 spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Length)];

        // ���ο� ��ġ�� ���� ����
        Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
    }
}