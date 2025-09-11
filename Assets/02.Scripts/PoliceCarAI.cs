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

    // �ٸ� �ݶ��̴��� �������� �� ȣ��Ǵ� �Լ�
    void OnTriggerEnter(Collider other)
    {
        // If the collided object has the "Player" tag
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                // Call the Die() method on the specific playerController instance
                playerController.Die();
            }
        }
    }
}