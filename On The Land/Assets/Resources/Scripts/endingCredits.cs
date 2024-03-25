using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endingCredits : MonoBehaviour
{

    public float scrollSpeed = 20f; // 크레딧 스크롤 속도
    public RectTransform creditsText; // 크레딧 텍스트의 RectTransform

    private void Start()
    {
        // 크레딧 텍스트 시작 위치를 화면 아래로 설정
        creditsText.anchoredPosition = new Vector2(0f, -Screen.height);
    }

    private void Update()
    {
        // 크레딧을 아래로 스크롤
        creditsText.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        // 만약 크레딧이 화면을 벗어나면 초기 위치로 이동
        if (creditsText.anchoredPosition.y >= 0f)
        {
            // 크레딧 텍스트 시작 위치를 화면 아래로 설정
            creditsText.anchoredPosition = new Vector2(0f, -Screen.height);
        }
    }

}
