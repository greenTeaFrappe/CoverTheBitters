using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logOutput : MonoBehaviour
{
    public Button logBtn;
    public Button backBtn;

    public ScrollRect scrollRect;
    public Text logText;

    private ScriptOutput scriptOutput; // ScriptOutput 컴포넌트를 참조하기 위한 변수 추가

    public int logCount;

    private void Start()
    {
        scrollRect.gameObject.SetActive(false);
        backBtn.gameObject.SetActive(false);
        logBtn.onClick.AddListener(TaskOnClick);

        // ScriptOutput 컴포넌트 가져오기
        scriptOutput = GetComponent<ScriptOutput>();

        // logText가 null이면 자식 오브젝트에서 찾아서 할당
        if (logText == null)
        {
            logText = GetComponentInChildren<Text>();
        }
    }

    void TaskOnClick()
    {
        scrollRect.gameObject.SetActive(true);
        backBtn.gameObject.SetActive(true);
        
        logBtn.gameObject.SetActive(false);
        
        backBtn.onClick.AddListener(Task2OnClick);

        // ScriptOutput 컴포넌트가 존재하고 logText가 null이 아닌지 확인
        if (logText != null && scriptOutput != null)
        {
            // count 변수만큼의 요소들을 logText에 추가
            for (int i = 0; i < scriptOutput.count; i++)
            {
                logText.text += "\n" + scriptOutput.names[i] + " : " + scriptOutput.texts[i] + "\n";
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
