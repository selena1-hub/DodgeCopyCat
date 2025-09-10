using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameStarted = false;
    private bool isGameOver = false;

    public GameObject playerObject;
    public GameObject policeSpawnerObject;

    void Start()
    {
        isGameStarted = false;
        isGameOver = false;

        playerObject.SetActive(true);
        policeSpawnerObject.SetActive(false);
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

    public void GameOver(bool isWin)
    {
        if (isGameOver) return;

        isGameOver = true;
        playerObject.SetActive(false);
        policeSpawnerObject.SetActive(false);

        if (isWin)
        {
            Debug.Log("You Win!");
        }
        else
        {
            Debug.Log("Game Over");
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}