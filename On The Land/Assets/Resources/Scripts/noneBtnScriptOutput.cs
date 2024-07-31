using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class noneBtnScriptOutput : MonoBehaviour
{
    public Button logBtn;
    public Button logbackBtn;
    public ScrollRect scrollRect;

    public Button autoBtn;
    public Text autoBtnText;

    public GameObject loadScreen;
    public Button loadBtn;
    public Button loadBackBtn;

    public Button skipBtn;

    // �迭 ���� ����
    public string[] texts;
    public int[] facialExpressions;
    public string[] names;
    public Sprite[] pfpImages;
    public string[] locations;

    public Text locationText;

    public int count = 0;
    public Text nameText;
    public Text scripts;
    public float speed;

    private bool isButtonClicked = false;
    private Coroutine autoCoroutine;

    public string nextSceneName;

    private void Start()
    {
        HandleMouseClick();

        autoBtn.onClick.AddListener(autoBtnClick);
        skipBtn.onClick.AddListener(() =>
        {
            count = texts.Length;
            HandleMouseClick();
        });

        loadScreen.gameObject.SetActive(false);

        loadBtn.onClick.AddListener(() =>
        {
            loadScreen.gameObject.SetActive(true);
            loadBackBtn.onClick.AddListener(() =>
            {
                loadScreen.gameObject.SetActive(false);
            });
        });
    }

    private void Update()
    {
        if (!scrollRect.gameObject.activeSelf && !logbackBtn.gameObject.activeSelf && logBtn.gameObject.activeSelf && !isButtonClicked && !loadScreen.gameObject.activeSelf)
        {

            // ���콺 Ŭ�� ����
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
            {

                HandleMouseClick();
                //Ŭ�� ó��
            }
        }
    }

    private void HandleMouseClick()
    {
        if(count< texts.Length)
        {
            nameText.text = names[count];
            scripts.text = texts[count];
            locationText.text = locations[count];

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
    private void autoBtnClick()
    {
        isButtonClicked = !isButtonClicked; // �ڵ� ���� ���¸� ����մϴ�.

        if (isButtonClicked)
        {
            autoBtnText.text = "STOP"; // ��ư �ؽ�Ʈ�� "�Ͻ�����"�� �����մϴ�.

            skipBtn.gameObject.SetActive(false);
            logBtn.gameObject.SetActive(false);
            loadBtn.gameObject.SetActive(false);

            // ���콺 Ŭ�� ����
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
            {
                autoBtnClick();
                --count;
            }

            autoCoroutine = StartCoroutine(AutoModeRoutine());
        }
        else
        {
            skipBtn.gameObject.SetActive(true);
            logBtn.gameObject.SetActive(true);
            loadBtn.gameObject.SetActive(true);
            autoBtnText.text = "AUTO"; // ��ư �ؽ�Ʈ�� "�ڵ�����"���� �����մϴ�.
            if (autoCoroutine != null)
                StopCoroutine(autoCoroutine);
        }
    }
    private IEnumerator AutoModeRoutine()
    {
        while (count < texts.Length)
        {
            HandleMouseClick();
            yield return new WaitForSeconds(0.5f * (speed + 1));
        }
    }
}

