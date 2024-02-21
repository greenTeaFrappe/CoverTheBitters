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

    private void Update()
    {
        // ScriptOutput 컴포넌트가 존재하고 logText가 null이 아닌지 확인
        if (logText != null && scriptOutput != null && scriptOutput.count < scriptOutput.texts.Length)
        {
            // count에 해당하는 스크립트를 logText에 추가
            logText.text += "\n"+scriptOutput.names[scriptOutput.count] + " : " + scriptOutput.texts[scriptOutput.count] + "\n";

            // count 증가
            //scriptOutput.count++;
        }
        else if (logText != null && scriptOutput != null && scriptOutput.count >= scriptOutput.texts.Length)
        {
            // 스크립트가 끝나면 logText에 추가
            logText.text += "End of Script\n";
        }
        else
        {
            Debug.Log("error");
        }
    }

    void TaskOnClick()
    {
        scrollRect.gameObject.SetActive(true);
        backBtn.gameObject.SetActive(true);
        logBtn.gameObject.SetActive(false);

        backBtn.onClick.AddListener(Task2OnClick);
    }

    void Task2OnClick()
    {
        scrollRect.gameObject.SetActive(false);
        backBtn.gameObject.SetActive(false);
        logBtn.gameObject.SetActive(true);
    }
}
