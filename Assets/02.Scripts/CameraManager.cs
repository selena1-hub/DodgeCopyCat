using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // ����Ƽ �����Ϳ��� ������ ī�޶��
    public GameObject[] cameras;
    private int currentCameraIndex = 0;

    // �÷��̾� ������Ʈ
    public Transform target;
    // �÷��̾�κ��� ī�޶��� �Ÿ�
    public float distance = 10.0f;

    void Start()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].SetActive(false);
        }
        cameras[currentCameraIndex].SetActive(true);
    }

    void Update()
    {
        // 'G' Ű�� ������ ���� ī�޶�� ��ȯ
        if (Input.GetKeyDown(KeyCode.G))
        {
            cameras[currentCameraIndex].SetActive(false);
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
            cameras[currentCameraIndex].SetActive(true);
        }

        // ī�޶� �÷��̾ ���󰡰� �� (1��Ī ī�޶�� ����)
        if (currentCameraIndex != 0) // 0�� �ε���(FPS Camera)�� �ƴ� ���
        {
            // �÷��̾��� ��ġ�� ī�޶��� �Ÿ��� ������� ���ο� ��ġ ���
            Vector3 newPosition = target.position - (transform.forward * distance);
            // ī�޶��� ��ġ�� �ε巴�� ������Ʈ
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 5f);
        }
    }
}