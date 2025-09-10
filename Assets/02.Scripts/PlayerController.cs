using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 플레이어의 이동 속도
    public float moveSpeed = 5.0f;

    void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트의 태그가 "Food"인지 확인
        if (other.CompareTag("Food"))
        {
            // 플레이어 크기 키우기
            GrowPlayer();
        }
    }

    void Update()
    {
        // 키보드 입력 받기
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 이동 방향 벡터 계산
        Vector3 moveDirection = new Vector3(h, 0, v);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    public void GrowPlayer()
    {
        Vector3 currentScale = transform.localScale;
        transform.localScale = currentScale + new Vector3(0.1f, 0.1f, 0.1f);
    }
}