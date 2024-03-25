using UnityEngine;
using UnityEngine.SceneManagement;

public class endingCredits : MonoBehaviour
{
    public float normalScrollSpeed = 20f; // �Ϲ����� ũ���� ��ũ�� �ӵ�
    public float fastScrollSpeed = 100f; // ���� ũ���� ��ũ�� �ӵ�
    public RectTransform creditsText; // ũ���� �ؽ�Ʈ�� RectTransform
    public string sceneName = "4. MAIN"; // �̵��� ���� �̸�

    private float currentScrollSpeed; // ���� ũ���� ��ũ�� �ӵ�

    private void Start()
    {
        // ũ���� �ؽ�Ʈ ���� ��ġ�� ȭ�� �Ʒ��� ����
        creditsText.anchoredPosition = new Vector2(0f, -Screen.height);

        // �ʱ� ũ���� ��ũ�� �ӵ� ����
        currentScrollSpeed = normalScrollSpeed;
    }

    private void Update()
    {
        // ũ������ �Ʒ��� ��ũ��
        creditsText.anchoredPosition += Vector2.up * currentScrollSpeed * Time.deltaTime;

        // ���� ũ������ ȭ���� ����� ���� ������ ��ȯ
        if (creditsText.anchoredPosition.y >= 0f)
        {
            ChangeScene();
        }

        // Ű�� ������ �ִ� ������ ���� ũ���� ��ũ�� �ӵ��� ����
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            currentScrollSpeed = fastScrollSpeed;
        }

        // Ű�� �� ��쿡�� �Ϲ����� ũ���� ��ũ�� �ӵ��� ����
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Return))
        {
            currentScrollSpeed = normalScrollSpeed;
        }
    }

    void ChangeScene()
    {
        // sceneName ������ ������ ������ ��ȯ
        SceneManager.LoadScene(sceneName);
    }
}
