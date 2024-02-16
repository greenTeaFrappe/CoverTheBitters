using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class btnScenesChange : MonoBehaviour
{
    // 다음으로 이동할 씬의 이름을 지정합니다.
    public string nextSceneName;
    public Button changeBtn;

    void Start()
    {
        Button btn = changeBtn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
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
