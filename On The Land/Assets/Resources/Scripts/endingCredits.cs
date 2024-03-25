using UnityEngine;
using UnityEngine.SceneManagement;

public class endingCredits : MonoBehaviour
{
    public float normalScrollSpeed = 20f; // 일반적인 크레딧 스크롤 속도
    public float fastScrollSpeed = 100f; // 빠른 크레딧 스크롤 속도
    public RectTransform creditsText; // 크레딧 텍스트의 RectTransform
    public string sceneName = "4. MAIN"; // 이동할 씬의 이름

    private float currentScrollSpeed; // 현재 크레딧 스크롤 속도

    private void Start()
    {
        // 크레딧 텍스트 시작 위치를 화면 아래로 설정
        creditsText.anchoredPosition = new Vector2(0f, -Screen.height);

        // 초기 크레딧 스크롤 속도 설정
        currentScrollSpeed = normalScrollSpeed;
    }

    private void Update()
    {
        // 크레딧을 아래로 스크롤
        creditsText.anchoredPosition += Vector2.up * currentScrollSpeed * Time.deltaTime;

        // 만약 크레딧이 화면을 벗어나면 다음 씬으로 전환
        if (creditsText.anchoredPosition.y >= 0f)
        {
            ChangeScene();
        }

        // 키를 누르고 있는 동안은 빠른 크레딧 스크롤 속도로 변경
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            currentScrollSpeed = fastScrollSpeed;
        }

        // 키를 뗀 경우에는 일반적인 크레딧 스크롤 속도로 변경
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Return))
        {
            currentScrollSpeed = normalScrollSpeed;
        }
    }

    void ChangeScene()
    {
        // sceneName 변수에 지정된 씬으로 전환
        SceneManager.LoadScene(sceneName);
    }
}
