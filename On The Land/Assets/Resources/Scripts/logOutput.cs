using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class logOutput : MonoBehaviour
{
    public Button logBtn;
    public Button backBtn;

    public ScrollRect scrollRect;
    public GameObject chatItemPrefab; // 대화 항목 프리팹
    public Transform content; // ScrollRect Content

    private ScriptOutput scriptOutput; // ScriptOutput 컴포넌트를 참조하기 위한 변수 추가

    public int logCount;

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

                // 텍스트와 이미지 설정
                UnityEngine.UI.Text chatText = chatItem.GetComponentInChildren<UnityEngine.UI.Text>();
                UnityEngine.UI.Image chatImage = chatItem.GetComponentInChildren<UnityEngine.UI.Image>();

                if (chatText != null)
                {
                    chatText.text = scriptOutput.names[i] + " : " + scriptOutput.texts[i];
                }

                if (chatImage != null)
                {
                    switch (scriptOutput.names[i])
                    {
                        case "안나": //피안화
                            chatImage.sprite = scriptOutput.pfpImages[0];
                            break;
                        case "아이작": //피이삭
                            chatImage.sprite = scriptOutput.pfpImages[1];
                            break;
                        case "아서": //하수호
                            chatImage.sprite = scriptOutput.pfpImages[2];
                            break;
                        case "양소미":
                            chatImage.sprite = scriptOutput.pfpImages[3];
                            break;
                        default: // 그 외 등장인물
                            chatImage.sprite = scriptOutput.pfpImages[4];
                            break;
                    }
                }
            }
        }
    }

    void Task2OnClick()
    {
        scrollRect.gameObject.SetActive(false);
        backBtn.gameObject.SetActive(false);

        logBtn.gameObject.SetActive(true);
    }
}
