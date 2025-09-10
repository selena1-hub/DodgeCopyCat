using UnityEngine;

public class FoodManager : MonoBehaviour
{
    // 유니티 에디터에서 연결할 프리팹
    public GameObject foodPrefab;
    public Transform playerTransform;

    // 땅의 크기에 맞춰서 정확하게 지정된 좌표
    // (50x50 크기의 땅을 기준으로 설정)
    private Vector3[] spawnPositions = new Vector3[]
    {
        // 중앙 구역의 네 모서리
        new Vector3(15, 0.5f, 15),
        new Vector3(-15, 0.5f, 15),
        new Vector3(15, 0.5f, -15),
        new Vector3(-15, 0.5f, -15),
        // 중앙 구역의 네 가장자리
        new Vector3(0, 0.5f, 15),
        new Vector3(0, 0.5f, -15),
        new Vector3(15, 0.5f, 0),
        new Vector3(-15, 0.5f, 0)
    };

    void Start()
    {
        // 게임 시작 시 음식 하나 생성
        SpawnFood();
    }

    public void SpawnFood()
    {
        // 랜덤으로 위치 선택
        Vector3 spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Length)];

        // 새로운 위치에 음식 생성
        Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
    }
}