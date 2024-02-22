using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScriptOutput : MonoBehaviour
{
    public struct scriptstruct
    {
        public string text;
        public int index;
    }
    public scriptstruct[] scriptArray = new scriptstruct[];
    public Text legacyText;
    public Button myButton;
    public Button myButton1;
    public Image img;
    
    public Image normal;
    public Image smile;
    public Image angry;
    public Image embarrassing;
    public Image serious;
    public Image avoidingGaze;

    private int currentIndex = 0;
    private float textChangeInterval = 2f; // 텍스트 변경 간격 (초)

    private void Start()
    {
        myButton.gameObject.SetActive(false);
        myButton1.gameObject.SetActive(false);

        img = GetComponent<Image>();

        StartCoroutine(UpdateTextWithDelay());
    }

    private IEnumerator UpdateTextWithDelay()
    {
        for (; currentIndex < scriptArray.Length; currentIndex++)
        {
            legacyText.text = scriptArray[currentIndex].text;

            if (scriptArray[currentIndex].index == 0)
                img.sprite = normal;
            else if (scriptArray[currentIndex].index == 1)
                img.sprite = smile;
            else if (scriptArray[currentIndex].index == 2)
                img.sprite = angry;
            else if (scriptArray[currentIndex].index == 3)
                img.sprite = embarrassing;
            else if (scriptArray[currentIndex].index == 4)
                img.sprite = serious;
            else if (scriptArray[currentIndex].index == 5)
                img.sprite = avoidingGaze;


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
