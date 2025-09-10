using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrowPrefab; // 화살 프리팹 (Inspector에서 연결)
    public Transform playerTransform; // 플레이어의 위치 (Inspector에서 연결)
    public float spawnInterval = 2.0f; // 화살 생성 간격 (초)

    void Start()
    {
        // spawnInterval 간격으로 SpawnArrow 함수를 반복 호출
        InvokeRepeating("SpawnArrow", 1f, spawnInterval);
    }

    void SpawnArrow()
    {
        // 플레이어의 현재 위치
        Vector3 targetPosition = playerTransform.position;
        // 화살이 날아올 방향 벡터 계산
        Vector3 direction = (targetPosition - transform.position).normalized;

        // 화살 프리팹 생성
        GameObject newArrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);

        // 화살의 방향을 플레이어 쪽으로 회전
        newArrow.transform.LookAt(targetPosition);

        // ArrowController 스크립트의 목표 방향 설정 함수 호출
        newArrow.GetComponent<ArrowController>().SetTargetDirection(direction);
    }
}