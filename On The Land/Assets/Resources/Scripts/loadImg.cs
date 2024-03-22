 using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class loadImg : MonoBehaviour
{
    public Image[] imageSlots; // 이미지를 표시할 UI 이미지 배열
    public Sprite defaultImage; // 기본 이미지

    private List<Sprite> collectedImages = new List<Sprite>(); // 수집한 이미지들을 저장하는 리스트

    void Start()
    {
        LoadCollectedImages();
        DisplayCollectedImages();
    }

    void LoadCollectedImages()
    {
        for (int i = 0; i < imageSlots.Length; i++)
        {
            string imageKey = "CollectedImage" + i.ToString(); // 이미지 이름을 저장하는 키
            if (PlayerPrefs.HasKey(imageKey))
            {
                string imageName = PlayerPrefs.GetString(imageKey); // 이미지 이름을 가져옴
                // 리소스에서 이미지 로드
                Sprite loadedImage = Resources.Load<Sprite>("Images/" + imageName);
                if (loadedImage != null)
                {
                    collectedImages.Add(loadedImage); // 로드된 이미지를 리스트에 추가
                }
                else
                {
                    Debug.LogWarning("Failed to load image: " + imageName);
                }
            }
        }
    }

    // 수집한 이미지 UI에 표시
    void DisplayCollectedImages()
    {
        for (int i = 0; i < imageSlots.Length; i++)
        {
            if (collectedImages.Count > i)
            {
                imageSlots[i].sprite = collectedImages[i];
            }
            else
            {
                imageSlots[i].sprite = defaultImage;
            }
        }
    }
}
