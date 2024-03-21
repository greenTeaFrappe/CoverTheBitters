using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using static System.Net.Mime.MediaTypeNames;

public class noneBtnScriptOutput : MonoBehaviour
{
    public Button logBtn;
    public Button backBtn;
    public ScrollRect scrollRect;

    public Button autoBtn;
    public Text autoBtnText;

    public GameObject loadScreen;

    public Button skipBtn;

    // �迭 ���� ����
    public string[] texts;
    public int[] facialExpressions;
    public string[] names;

    public Text nameText;
    public Text scripts;

    public string nextSceneName;

    public bool isButtonClicked = false;

    private int count=0;

    private void autoBtnClick()
    {
        isButtonClicked = !isButtonClicked; // �ڵ� ���� ���¸� ����մϴ�.

        if (isButtonClicked)
        {
            autoBtnText.text = "�Ͻ�����"; // ��ư �ؽ�Ʈ�� "�Ͻ�����"�� �����մϴ�.
            InvokeRepeating(nameof(HandleMouseClick), 0f, 1f);
        }
        else
        {
            autoBtnText.text = "�ڵ�����"; // ��ư �ؽ�Ʈ�� "�ڵ�����"���� �����մϴ�.
            CancelInvoke(nameof(HandleMouseClick));
        }
    }

    private void Start()
    {
        nameText.text = names[count];
        scripts.text = texts[count];

        //state ���� �����ؾ���
        ScriptOutputState state = GetComponent<ScriptOutputState>();
        state.SOState(facialExpressions[count], names[count]);
        count++;

        autoBtn.onClick.AddListener(autoBtnClick);
        skipBtn.onClick.AddListener(skipBtnClick);
    }

    private void Update()
    {
        if (!scrollRect.gameObject.activeSelf && !backBtn.gameObject.activeSelf && logBtn.gameObject.activeSelf && !isButtonClicked)
        {
            // ���콺 Ŭ�� ����
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
            {
                HandleMouseClick();
            }
        }
    }

    private void HandleMouseClick()
    {
        if(count< texts.Length)
        {
            nameText.text = names[count];
            scripts.text = texts[count];

            //state ���� �����ؾ���
            ScriptOutputState state = GetComponent<ScriptOutputState>();
            state.SOState(facialExpressions[count], names[count]);
            count++;
        }
        else
        {
            //Scence Change
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                // Check if the scene exists
                if (SceneManager.GetSceneByName(nextSceneName) != null)
                {
                    // Log and load the scene
                    Debug.Log("�� ��ȯ");
                    SceneManager.LoadScene(nextSceneName);
                }
                else
                {
                    // Log an error if the scene doesn't exist
                    Debug.LogError("���� �������� �ʽ��ϴ�: " + nextSceneName);
                }
            }
            else
            {
                // Log an error if nextSceneName is null or empty
                Debug.LogError("���� ���� �̸��� �������� �ʾҽ��ϴ�.");
            }
        }
    }

    private void skipBtnClick()
    {
        count = texts.Length;

    }
}
