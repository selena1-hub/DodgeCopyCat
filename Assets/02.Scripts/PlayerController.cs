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
        // 리지드바디의 속도에 newVeclocity 할당
        rb.linearVelocity = newVelocity;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishZone"))
        {
            if (gameManager != null)
            {
                gameManager.GameOver(true);
            }
        }
    }

    //void FixedUpdate()
    //{
    //    float h = Input.GetAxis("Horizontal");
    //    float v = Input.GetAxis("Vertical");

    //    Vector3 moveDirection = new Vector3(h, 0, v);

    //    // 이동 방향이 0이 아닐 때만 플레이어의 방향을 회전
    //    if (moveDirection != Vector3.zero)
    //    {
    //        // 이동 방향을 바라보게 함 (Y축만 회전)
    //        transform.LookAt(transform.position + moveDirection);
    //    }

    //    rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    //}
}