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

    // 배열 변수 선언
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
        isButtonClicked = !isButtonClicked; // 자동 진행 상태를 토글합니다.

        if (isButtonClicked)
        {
            autoBtnText.text = "일시정지"; // 버튼 텍스트를 "일시정지"로 변경합니다.
            InvokeRepeating(nameof(HandleMouseClick), 0f, 1f);
        }
        else
        {
            autoBtnText.text = "자동진행"; // 버튼 텍스트를 "자동진행"으로 변경합니다.
            CancelInvoke(nameof(HandleMouseClick));
        }
    }

    private void Start()
    {
        nameText.text = names[count];
        scripts.text = texts[count];

        //state 패턴 적용해야함
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
            // 마우스 클릭 감지
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

            //state 패턴 적용해야함
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
                    Debug.Log("씬 전환");
                    SceneManager.LoadScene(nextSceneName);
                }
                else
                {
                    // Log an error if the scene doesn't exist
                    Debug.LogError("씬이 존재하지 않습니다: " + nextSceneName);
                }
            }
            else
            {
                // Log an error if nextSceneName is null or empty
                Debug.LogError("다음 씬의 이름이 지정되지 않았습니다.");
            }
        }
    }

    private void skipBtnClick()
    {
        count = texts.Length;

    }
}
