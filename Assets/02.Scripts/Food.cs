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
        // Debug.Log�� �߰��Ͽ� �Լ��� ����Ǵ��� Ȯ��
        Debug.Log("Player collided with food!");

        // �浹�� ������Ʈ�� �÷��̾����� Ȯ��
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

            // �� �κ��� ������ �����ϴ� �ڵ��Դϴ�.
            Destroy(gameObject);
        }
    }
}