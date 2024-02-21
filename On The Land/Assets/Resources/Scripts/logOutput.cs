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

    private ScriptOutput scriptOutput; // ScriptOutput ������Ʈ�� �����ϱ� ���� ���� �߰�

    public int logCount;

    private void Start()
    {
        scrollRect.gameObject.SetActive(false);
        backBtn.gameObject.SetActive(false);
        logBtn.onClick.AddListener(TaskOnClick);

        // ScriptOutput ������Ʈ ��������
        scriptOutput = GetComponent<ScriptOutput>();

        // logText�� null�̸� �ڽ� ������Ʈ���� ã�Ƽ� �Ҵ�
        if (logText == null)
        {
            logText = GetComponentInChildren<Text>();
        }
    }

    private void Update()
    {
        
        // ScriptOutput ������Ʈ�� �����ϰ� logText�� null�� �ƴ��� Ȯ��
        if (logText != null && scriptOutput != null && scriptOutput.count < scriptOutput.texts.Length &&logCount==scriptOutput.count)
        {
            // count�� �ش��ϴ� ��ũ��Ʈ�� logText�� �߰�
            logText.text += "\n" + scriptOutput.names[scriptOutput.count] + " : " + scriptOutput.texts[scriptOutput.count] + "\n";
            logCount++;
        }
        else if (logText != null && scriptOutput != null && scriptOutput.count >= scriptOutput.texts.Length &&logCount>=scriptOutput.texts.Length)
        {
            // ��ũ��Ʈ�� ������ logText�� �߰�
            Debug.Log("End of Script");
            logCount = 0;
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
