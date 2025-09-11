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
    public TextMeshProUGUI killText; // 패배 텍스트 (예: "YOU DIED")

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

    // --- 여기가 수정된 부분입니다 ---
    public void GameOver(bool isWin)
    {
        if (isGameOver) return;
        isGameOver = true;

        playerObject.SetActive(false);
        DestroyAllPoliceCars();

        if (isWin) // 만약 isWin이 true라면 (승리했다면)
        {
            if (winText != null)
            {
                winText.gameObject.SetActive(true); // 승리 텍스트를 켭니다.
            }
        }
        else // 그렇지 않고 isWin이 false라면 (패배했다면)
        {
            if (killText != null)
            {
                killText.gameObject.SetActive(true); // 패배 텍스트를 켭니다.
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