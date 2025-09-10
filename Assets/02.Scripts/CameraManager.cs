using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // 유니티 에디터에서 연결할 카메라들
    public GameObject[] cameras;
    private int currentCameraIndex = 0;

    // 플레이어 오브젝트
    public Transform target;
    // 플레이어로부터 카메라의 거리
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
        // 'G' 키를 누르면 다음 카메라로 전환
        if (Input.GetKeyDown(KeyCode.G))
        {
            cameras[currentCameraIndex].SetActive(false);
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
            cameras[currentCameraIndex].SetActive(true);
        }

        // 카메라가 플레이어를 따라가게 함 (1인칭 카메라는 제외)
        if (currentCameraIndex != 0) // 0번 인덱스(FPS Camera)가 아닐 경우
        {
            // 플레이어의 위치와 카메라의 거리를 기반으로 새로운 위치 계산
            Vector3 newPosition = target.position - (transform.forward * distance);
            // 카메라의 위치를 부드럽게 업데이트
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 5f);
        }
    }
}