using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScriptOutput : MonoBehaviour
{
    class script
    {
        public string text;
        public int charName;
        public int charFace;
    }

    script[] scriptArray;

    public Text legacyText;
    public Button myButton;
    public Button myButton1;
    public Image img;

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

            // 이미지 스프라이트 할당 (주석 해제하여 사용)
            /*
            if (scriptArray[currentIndex].index == 0)
                img.sprite = "\Assets\Sprites\금발여캐1.png";
            else if (scriptArray[currentIndex].index == 1)
                img.sprite = smile;
            // 더 많은 조건 추가
            */

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