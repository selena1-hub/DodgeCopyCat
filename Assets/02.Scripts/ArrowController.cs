using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float arrowSpeed = 15f;
    private Vector3 targetDirection;
    private GameManager gameManager; // GameManager를 참조하기 위한 변수

    void Start()
    {
        // GameManager 오브젝트를 찾아 스크립트를 가져옴
        gameManager = FindObjectOfType<GameManager>();
    }

    public void SetTargetDirection(Vector3 direction)
    {
        targetDirection = direction;
    }

    void Update()
    {
        transform.Translate(targetDirection * arrowSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager != null)
            {
                // true를 넘겨서 플레이어가 '패배'했음을 알림
                gameManager.GameOver(false);
            }
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}