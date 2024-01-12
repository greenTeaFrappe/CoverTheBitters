using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScriptOutput : MonoBehaviour
{
    //public string[] textArray;

    //scriptArray로 바꿔오기 
    struct scriptstruct
    {
        public string text;
        public int index;
    }
    public scriptstruct[] scriptArray = new scriptstruct[];
    public Text legacyText;
    public Button myButton;
    public Button myButton1;

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

            if (currentIndex >= scriptArray.Length)
            {
                myButton.gameObject.SetActive(true);
                myButton1.gameObject.SetActive(true);
            }
            else
            {
                yield return new WaitForSecond(textChangeInterval);
            }
        }
    }
}
