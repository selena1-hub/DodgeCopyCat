using UnityEngine;

public class PoliceCarSpawner : MonoBehaviour
{
    // 유니티 에디터에서 연결할 경찰차 프리팹
    public GameObject policeCarPrefab;
    // 플레이어의 위치를 추격 대상으로 설정하기 위해
    public Transform playerTransform;

    void Start()
    {
        // 게임 시작 시 단 한 대의 경찰차만 생성
        SpawnPoliceCar();
    }

    void SpawnPoliceCar()
    {
        // 경찰차 프리팹 생성
        GameObject newPoliceCar = Instantiate(policeCarPrefab, transform.position, Quaternion.identity);

        // 생성된 경찰차의 AI 스크립트를 가져와 플레이어의 위치를 알려줌
        PoliceCarAI policeCarAI = newPoliceCar.GetComponent<PoliceCarAI>();
        if (policeCarAI != null)
        {
            policeCarAI.SetTarget(playerTransform);
        }
    }
}