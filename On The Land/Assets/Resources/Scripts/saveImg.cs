using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveImg : MonoBehaviour
{
    public Sprite collectedImage; // 수집할 이미지
    public Button collectButton; // 이미지를 수집할 버튼

    private bool isCollected = false; // 이미지가 수집되었는지 여부

    void Start()
    {
        // 이미지 수집 버튼에 클릭 이벤트 리스너 추가
        collectButton.onClick.AddListener(CollectImage);
    }

    void CollectImage()
    {
        // 이미지가 아직 수집되지 않은 경우에만 수집 상태를 업데이트하고 PlayerPref에 저장
        if (!isCollected)
        {
            isCollected = true;
            PlayerPrefs.SetInt("CollectedImage_" + gameObject.name, 1); // 이미지가 수집된 것으로 표시
            PlayerPrefs.Save(); // 변경 사항을 저장

            // UI 상에 이미지 추가 등의 업데이트 로직을 여기에 추가할 수 있습니다.
            Debug.Log("Image collected: " + collectedImage.name);
        }
        else
        {
            Debug.Log("Image already collected!");
        }
    }
}
