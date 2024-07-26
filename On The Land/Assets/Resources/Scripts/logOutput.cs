using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class logOutput : MonoBehaviour
{
    public Button logBtn;
    public Button backBtn;

    public ScrollRect scrollRect;
    public GameObject chatItemPrefab; // 대화 항목 프리팹
    public Transform content; // ScrollRect Content

    private ScriptOutput scriptOutput; // ScriptOutput 컴포넌트를 참조하기 위한 변수 추가

    public int logCount;
    public int itemHeight = 100;


    private void Start()
    {
        scrollRect.gameObject.SetActive(false);
        backBtn.gameObject.SetActive(false);
        logBtn.onClick.AddListener(TaskOnClick);

        // ScriptOutput 컴포넌트 가져오기
        scriptOutput = GetComponent<ScriptOutput>();

        // content가 null이면 자식 오브젝트에서 찾아서 할당
        if (content == null)
        {
            content = scrollRect.content;
        }
    }

    void TaskOnClick()
    {
        scrollRect.gameObject.SetActive(true);
        backBtn.gameObject.SetActive(true);

        logBtn.gameObject.SetActive(false);

        backBtn.onClick.AddListener(Task2OnClick);

        // ScriptOutput 컴포넌트가 존재하는지 확인
        if (scriptOutput != null)
        {
            // 기존 대화 항목 삭제
            foreach (Transform child in content)
            {
                Destroy(child.gameObject);
            }

            // count 변수만큼의 요소들을 생성하여 content에 추가
            for (int i = 0; i < scriptOutput.count; i++)
            {
                GameObject chatItem = Instantiate(chatItemPrefab, content);

                // 프리팹 내부의 logText와 chatImage 오브젝트 찾기
                TextMeshProUGUI logText = chatItem.transform.Find("logText").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI name = chatItem.transform.Find("name").GetComponent<TextMeshProUGUI>();
                UnityEngine.UI.Image pfpImg = chatItem.transform.Find("pfpImg").GetComponent<UnityEngine.UI.Image>();

                if (logText != null && name != null)
                {
                    logText.text = scriptOutput.texts[i];
                    name.text = scriptOutput.names[i];
                }

                if (pfpImg != null)
                {
                    switch (scriptOutput.names[i])
                    {
                        case "안나": //피안화
                            pfpImg.sprite = scriptOutput.pfpImages[0];
                            break;
                        case "아이작": //피이삭
                            pfpImg.sprite = scriptOutput.pfpImages[1];
                            break;
                        case "아서": //하수호
                            pfpImg.sprite = scriptOutput.pfpImages[2];
                            break;
                        case "양소미":
                            pfpImg.sprite = scriptOutput.pfpImages[3];
                            break;
                        default: // 그 외 등장인물
                            pfpImg.sprite = scriptOutput.pfpImages[4];
                            break;
                    }
                }
                RectTransform chatItemRect = chatItem.GetComponent<RectTransform>();
                chatItemRect.anchoredPosition = new Vector2(0, -i * itemHeight);

            }
            RectTransform contentRect = content.GetComponent<RectTransform>();
            contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, scriptOutput.count * itemHeight);
        }
    }

    void Task2OnClick()
    {
        scrollRect.gameObject.SetActive(false);
        backBtn.gameObject.SetActive(false);

        logBtn.gameObject.SetActive(true);
    }
}
