using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveImg : MonoBehaviour
{

    private const string EAIMG_KEY = "EAIMG"; // EAIMG 이미지를 저장할 플레이어 프레프스 키
    private const string SAIMG_KEY = "SAIMG"; // SAIMG 이미지를 저장할 플레이어 프레프스 키


    public void collectAndSaveImg(Texture2D image, string eventType)
    {

        // 이미지를 Base64로 인코딩하여 문자열로 변환
        string base64EncodedImage = System.Convert.ToBase64String(image.EncodeToPNG());

        // 이벤트 타입에 따라 플레이어 프레프스에 저장
        switch (eventType)
        {
            case "EAIMG":
                PlayerPrefs.SetString("EAIMG_KEY", base64EncodedImage);
                break;
            case "SAIMG":
                PlayerPrefs.SetString("SAIMG_KEY", base64EncodedImage);
                break;
            default:
                Debug.LogError("Unknown event type: " + eventType);
                return;
        }

        // 변경된 내용을 저장
        PlayerPrefs.Save();
    }
}
