using UnityEngine;

public class PoliceCarAI : MonoBehaviour
{
    private Transform target;
    public float speed = 10f;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    // 다른 콜라이더와 접촉했을 때 호출되는 함수
    void OnTriggerEnter(Collider other)
    {
        // 접촉한 오브젝트가 "Player" 태그를 가졌다면
        if (other.CompareTag("Player"))
        {
            if (gameManager != null)
            {
                gameManager.GameOver(false); // 패배 처리
            }
            // 플레이어 오브젝트를 파괴하여 화면에서 사라지게 함
            Destroy(other.gameObject);
        }
    }
}