using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ���� ���� ������
    public GameObject playerObject;
    public GameObject arrowSpawnerObject;
    public GameObject foodManagerObject;

    private bool isGameOver = false;
    private bool isGameStarted = false;

    // ī�޶� ���� ������
    public GameObject[] cameras;
    private int currentCameraIndex = 0;
    public Transform target;
    public float distance = 10.0f;

    void Start()
    {
        isGameOver = false;
        isGameStarted = false;

        // ���� ���� ������ ��� ���� ������Ʈ�� ��Ȱ��ȭ
        playerObject.SetActive(false);
        arrowSpawnerObject.SetActive(false);
        foodManagerObject.SetActive(false);

        // ��� ī�޶� ��Ȱ��ȭ�ϰ�, ���� ī�޶� Ȱ��ȭ
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
        // ���� ���� �����̰� 'R' Ű�� ������ �����
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        // ������ ���۵Ǿ��� ���� ī�޶� ���� ���
        if (isGameStarted)
        {
            // 'G' Ű�� ������ ���� ī�޶�� ��ȯ
            if (Input.GetKeyDown(KeyCode.G))
            {
                cameras[currentCameraIndex].SetActive(false);
                currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
                cameras[currentCameraIndex].SetActive(true);
            }

            // ī�޶� �÷��̾ ���󰡰� �� (1��Ī ī�޶�� ����)
            if (currentCameraIndex != 0 && target != null)
            {
                Vector3 newPosition = target.position - (transform.forward * distance);
                transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 5f);
            }

            // 'X' Ű�� ������ Ȯ�� (�Ÿ��� �������)
            if (Input.GetKey(KeyCode.X))
            {
                distance = Mathf.Max(3f, distance - Time.deltaTime * 5f);
            }

            // 'Y' Ű�� ������ ��� (�Ÿ��� �־���)
            if (Input.GetKey(KeyCode.Y))
            {
                distance = Mathf.Min(20f, distance + Time.deltaTime * 5f);
            }
        }
    }

    public void StartGame()
    {
        isGameStarted = true;

        // ���� ���� ��ư�� ������ ��� ���� ������Ʈ�� Ȱ��ȭ
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
        // ������ ���۵��� �ʾ��� ���� ����/���� ��ư�� �׸�
        if (!isGameStarted)
        {
            Rect startButtonRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 50);
            if (GUI.Button(startButtonRect, "���� ����"))
            {
                StartGame();
            }

            Rect exitButtonRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 + 10, 200, 50);
            if (GUI.Button(exitButtonRect, "���� ����"))
            {
                Application.Quit();
            }
        }

        // ���� ���� ������ ���� ����� ��ư�� �׸�
        if (isGameOver)
        {
            Rect restartButtonRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 50);
            if (GUI.Button(restartButtonRect, "����� (R)"))
            {
                RestartGame();
            }
        }
    }
}