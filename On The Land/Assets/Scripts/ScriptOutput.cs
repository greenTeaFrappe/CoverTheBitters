using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScriptOutput : MonoBehaviour
{
    public class scriptStruct
    {
        public string text;
        public int name;
        public int index;
    }

    public string[] charNameArray = new string[]
    {
        "금발여캐","청발여캐"
    };

    public Text legacyText;

    public scriptStruct[] scriptArray = new scriptStruct[]
    {
        new scriptStruct{text="text1",name=0,index=0},
        new scriptStruct{text="text2",name=1,index=1},
        new scriptStruct{text="text3",name=0,index=2},
        new scriptStruct{text="text4",name=0,index=3},
        new scriptStruct{text="text5",name=0,index=4},
     //   // 필요에 따라 더 많은 항목 추가
    };

    public Button myButton;
    public Button myButton1;

    public Image img;
    public Sprite nomal, angry, sad, shy, smile;

    public Text charNameText;

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
            {
                img.sprite = nomal;
                Debug.Log("nomal");
            }
            else if (scriptArray[currentIndex].index == 1)
            {
                img.sprite = angry;
                Debug.Log("angry");
            }
            else if (scriptArray[currentIndex].index == 2)
            {
                img.sprite = sad;
                Debug.Log("sad");
            }
            else if (scriptArray[currentIndex].index == 3)
            {
                img.sprite = shy;
                Debug.Log("shy");
            }
            else if (scriptArray[currentIndex].index == 4)
            {
                img.sprite = smile;
                Debug.Log("smile");
            }

            charNameText.text = charNameArray[scriptArray[currentIndex].name];

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