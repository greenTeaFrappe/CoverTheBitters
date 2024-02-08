using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScriptOutput : MonoBehaviour
{
    public struct ScriptStruct
    {
        public string text;
        public int name; //캐릭터 이름
        public int index;
    }

    public ScriptStruct[] scriptArray = new ScriptStruct[]
    {
        new ScriptStruct { text = "텍스트1", index = 0 },
        new ScriptStruct { text = "텍스트2", index = 1 },
        // 필요에 따라 더 많은 항목 추가
    };

    public Text legacyText;
    public Button myButton;
    public Button myButton1;

    public Image img;
    public Sprite nomal, angry, sad, shy, smile;

    private int currentIndex = 0;
    private float textChangeInterval = 2f; // 텍스트 변경 간격 (초)

    private void Start()
    {
        myButton.gameObject.SetActive(false);
        myButton1.gameObject.SetActive(false);

        StartCoroutine(UpdateTextWithDelay());
    }

    private IEnumerator UpdateTextWithDelay()
    {
        for (; currentIndex < scriptArray.Length; currentIndex++)
        {
            legacyText.text = scriptArray[currentIndex].text;

            // 이미지 스프라이트 할당 

            if (scriptArray[currentIndex].index == 0)
                img.sprite = nomal;
            else if (scriptArray[currentIndex].index == 1)
                img.sprite = angry;
            else if (scriptArray[currentIndex].index == 2)
                img.sprite = sad;
            else if (scriptArray[currentIndex].index == 3)
                img.sprite = shy;
            else if (scriptArray[currentIndex].index == 4)
                img.sprite = smile;
            else
                Debug.Log("no such index (face)");

            Debug.Log("Complete");

            if (currentIndex >= scriptArray.Length)
            {
                myButton.gameObject.SetActive(true);
                myButton1.gameObject.SetActive(true);
            }
            else
            {
                yield return new WaitForSeconds(textChangeInterval);
            }
        }
    }
}