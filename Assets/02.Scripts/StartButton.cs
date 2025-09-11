using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // 버튼 기능을 위해 필요합니다.

public class StartButton : MonoBehaviour
{
    void Start()
    {
        // 이 스크립트가 붙어있는 버튼 컴포넌트를 가져옵니다.
        Button btn = this.GetComponent<Button>();

        // 버튼 클릭 시 씬을 변경하는 기능을 연결합니다.
        btn.onClick.AddListener(() =>
        {
            // "게임 화면" 씬을 불러옵니다.
            // 씬 이름 대신 '1'과 같이 씬의 빌드 번호를 사용해도 됩니다.
            SceneManager.LoadScene(1);
        });
    }
}