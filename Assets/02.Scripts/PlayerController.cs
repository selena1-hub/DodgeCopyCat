using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Rigidbody rb;
    private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // 수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력값과 이동 속력을 통해 결정
        float xSpeed = xInput * moveSpeed;
        float zSpeed = zInput * moveSpeed;

        // Vector3 속도를 (xSpeed, 0f, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        if (newVelocity != Vector3.zero)
        {
            transform.forward = Vector3.Lerp(transform.forward, newVelocity, 0.1f);
        }

        // 리지드바디의 속도에 newVelocity 할당
        rb.linearVelocity = newVelocity;
    }

    // --- 이 부분이 Update() 함수 밖으로 나와야 합니다 ---
    void OnTriggerEnter(Collider other)
    {
        // 닿은 물체의 태그가 "FinishZone"인지 확인
        if (other.CompareTag("FinishZone"))
        {
            if (gameManager != null)
            {
                // 게임 매니저의 GameOver 함수를 호출하고 승리(true)를 전달
                gameManager.GameOver(true);
            }
        }
    }

    public void Die()
    {
        if (gameManager != null)
        {
            // false를 넘겨서 플레이어가 '패배'했음을 알림
            gameManager.GameOver(false);
        }
        // 플레이어 오브젝트를 비활성화해서 화면에서 사라지게 함
        gameObject.SetActive(false);
    }
}