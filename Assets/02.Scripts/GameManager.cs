using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 게임 관리 변수들
    public GameObject playerObject;
    public GameObject arrowSpawnerObject;
    public GameObject foodManagerObject;

    private bool isGameOver = false;
    private bool isGameStarted = false;

    // 카메라 관리 변수들
    public GameObject[] cameras;
    private int currentCameraIndex = 0;
    public Transform target;
    public float distance = 10.0f;

    void Start()
    {
        isGameOver = false;
        isGameStarted = false;

        // 게임 시작 전에는 모든 게임 오브젝트를 비활성화
        playerObject.SetActive(false);
        arrowSpawnerObject.SetActive(false);
        foodManagerObject.SetActive(false);

        // 모든 카메라를 비활성화하고, 현재 카메라만 활성화
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].SetActive(false);
        }
        if (cameras.Length > 0)
        {
            cameras[currentCameraIndex].SetActive(true);
        }
    }

    void Update()
    {
        // 게임 오버 상태이고 'R' 키를 누르면 재시작
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        // 게임이 시작되었을 때만 카메라 조작 허용
        if (isGameStarted)
        {
            // 'G' 키를 누르면 다음 카메라로 전환
            if (Input.GetKeyDown(KeyCode.G))
            {
                cameras[currentCameraIndex].SetActive(false);
                currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
                cameras[currentCameraIndex].SetActive(true);
            }

            // 카메라가 플레이어를 따라가게 함 (1인칭 카메라는 제외)
            if (currentCameraIndex != 0 && target != null)
            {
                Vector3 newPosition = target.position - (transform.forward * distance);
                transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 5f);
            }

            // 'X' 키를 누르면 확대 (거리가 가까워짐)
            if (Input.GetKey(KeyCode.X))
            {
                distance = Mathf.Max(3f, distance - Time.deltaTime * 5f);
            }

            // 'Y' 키를 누르면 축소 (거리가 멀어짐)
            if (Input.GetKey(KeyCode.Y))
            {
                distance = Mathf.Min(20f, distance + Time.deltaTime * 5f);
            }
        }
    }

    public void StartGame()
    {
        isGameStarted = true;

        // 게임 시작 버튼을 누르면 모든 게임 오브젝트를 활성화
        playerObject.SetActive(true);
        arrowSpawnerObject.SetActive(true);
        foodManagerObject.SetActive(true);
    }

    public void GameOver()
    {
        isGameOver = true;
        playerObject.SetActive(false);
        arrowSpawnerObject.SetActive(false);
        foodManagerObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnGUI()
    {
        // 게임이 시작되지 않았을 때만 시작/종료 버튼을 그림
        if (!isGameStarted)
        {
            Rect startButtonRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 50);
            if (GUI.Button(startButtonRect, "게임 시작"))
            {
                StartGame();
            }

            Rect exitButtonRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 + 10, 200, 50);
            if (GUI.Button(exitButtonRect, "게임 종료"))
            {
                Application.Quit();
            }
        }

        // 게임 오버 상태일 때만 재시작 버튼을 그림
        if (isGameOver)
        {
            Rect restartButtonRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 50);
            if (GUI.Button(restartButtonRect, "재시작 (R)"))
            {
                RestartGame();
            }
        }
    }
}