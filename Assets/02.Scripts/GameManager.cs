using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameStarted = false;
    private bool isGameOver = false;

    public GameObject playerObject;
    public GameObject policeSpawnerObject;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI killText; // �й� �ؽ�Ʈ (��: "YOU DIED")

    void Start()
    {
        isGameStarted = false;
        isGameOver = false;

        playerObject.SetActive(true);
        policeSpawnerObject.SetActive(true);

        if (winText != null)
        {
            winText.gameObject.SetActive(false);
        }
        if (killText != null)
        {
            killText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void StartGame()
    {
        isGameStarted = true;
        playerObject.SetActive(true);
        policeSpawnerObject.SetActive(true);
    }

    // --- ���Ⱑ ������ �κ��Դϴ� ---
    public void GameOver(bool isWin)
    {
        if (isGameOver) return;
        isGameOver = true;

        playerObject.SetActive(false);
        DestroyAllPoliceCars();

        if (isWin) // ���� isWin�� true��� (�¸��ߴٸ�)
        {
            if (winText != null)
            {
                winText.gameObject.SetActive(true); // �¸� �ؽ�Ʈ�� �մϴ�.
            }
        }
        else // �׷��� �ʰ� isWin�� false��� (�й��ߴٸ�)
        {
            if (killText != null)
            {
                killText.gameObject.SetActive(true); // �й� �ؽ�Ʈ�� �մϴ�.
            }
        }
    }

    void DestroyAllPoliceCars()
    {
        GameObject[] policeCars = GameObject.FindGameObjectsWithTag("PoliceCar");
        foreach (GameObject car in policeCars)
        {
            Destroy(car);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}