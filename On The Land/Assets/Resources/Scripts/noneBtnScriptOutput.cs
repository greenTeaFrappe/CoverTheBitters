using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class noneBtnScriptOutput : MonoBehaviour
{
    // 배열 변수 선언
    public string[] texts;
    public int[] facialExpressions;
    public string[] names;

    public Button logBtn;
    public Button backBtn;
    public ScrollRect scrollRect;

    public Text nameText;
    public Text scripts;

    private int count=0;

    public string nextSceneName;

    private void Update()
    {
        if (!scrollRect.gameObject.activeSelf && !backBtn.gameObject.activeSelf && logBtn.gameObject.activeSelf)
        {
            // 마우스 클릭 감지
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
            {
                HandleMouseClick();
                //클릭 처리
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

}
