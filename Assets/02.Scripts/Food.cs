using UnityEngine;

public class Food : MonoBehaviour
{
    private FoodManager foodManager;
    private PlayerController playerController;

    void Start()
    {
        foodManager = FindObjectOfType<FoodManager>();
        playerController = FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log를 추가하여 함수가 실행되는지 확인
        Debug.Log("Player collided with food!");

        // 충돌한 오브젝트가 플레이어인지 확인
        if (other.CompareTag("Player"))
        {
            if (playerController != null)
            {
                playerController.GrowPlayer();
            }

            if (foodManager != null)
            {
                foodManager.SpawnFood();
            }

            // 이 부분이 음식을 삭제하는 코드입니다.
            Destroy(gameObject);
        }
    }
}