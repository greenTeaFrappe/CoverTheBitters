using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class noneBtn_ScriptOutput : MonoBehaviour
{
    public string[] textArray;
    public Text legacyText;

    private int currentIndex = 0;
    private float textChangeInterval = 2f; // 텍스트 변경 간격 (초)

    private void Start()
    {

        StartCoroutine(UpdateTextWithDelay());
    }

    private IEnumerator UpdateTextWithDelay()
    {
        while (currentIndex < textArray.Length)
        {
            legacyText.text = textArray[currentIndex];
            currentIndex++;

            if (currentIndex >= textArray.Length)
            {
                //정해진바 없음.

            }
            else
            {
                yield return new WaitForSeconds(textChangeInterval);
            }
        }
    }
}
