using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // ��ư ����� ���� �ʿ��մϴ�.

public class StartButton : MonoBehaviour
{
    void Start()
    {
        // �� ��ũ��Ʈ�� �پ��ִ� ��ư ������Ʈ�� �����ɴϴ�.
        Button btn = this.GetComponent<Button>();

        // ��ư Ŭ�� �� ���� �����ϴ� ����� �����մϴ�.
        btn.onClick.AddListener(() =>
        {
            // "���� ȭ��" ���� �ҷ��ɴϴ�.
            // �� �̸� ��� '1'�� ���� ���� ���� ��ȣ�� ����ص� �˴ϴ�.
            SceneManager.LoadScene(1);
        });
    }
}