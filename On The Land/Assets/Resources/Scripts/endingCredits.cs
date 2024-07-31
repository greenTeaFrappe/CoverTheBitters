using UnityEngine;
using UnityEngine.SceneManagement;

public class endingCredits : MonoBehaviour
{
    public float normalScrollSpeed = 20f; // �Ϲ����� ũ���� ��ũ�� �ӵ�
    public float fastScrollSpeed = 100f; // ���� ũ���� ��ũ�� �ӵ�
    public RectTransform contentRect; // Scroll View > Viewport > Content�� RectTransform
    public RectTransform viewportRect; // Scroll View > Viewport�� RectTransform
    public string sceneName = "4. MAIN"; // �̵��� ���� �̸�

    private float currentScrollSpeed; // ���� ũ���� ��ũ�� �ӵ�

    private void Start()
    {
        // ũ���� �ؽ�Ʈ ���� ��ġ�� Scroll View �Ʒ��� ����
        contentRect.anchoredPosition = new Vector2(0f, -viewportRect.rect.height);

        // �ʱ� ũ���� ��ũ�� �ӵ� ����
        currentScrollSpeed = normalScrollSpeed;
    }

    private void Update()
    {
        // ũ������ ���� ��ũ��
        contentRect.anchoredPosition += Vector2.up * currentScrollSpeed * Time.deltaTime;

        // ���� ũ������ Scroll View�� ����� ���� ������ ��ȯ
        if (contentRect.anchoredPosition.y >= contentRect.rect.height - viewportRect.rect.height)
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
