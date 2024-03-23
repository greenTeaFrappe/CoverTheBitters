using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveImg : MonoBehaviour
{

    private const string EAIMG_KEY = "EAIMG"; // EAIMG �̹����� ������ �÷��̾� �������� Ű
    private const string SAIMG_KEY = "SAIMG"; // SAIMG �̹����� ������ �÷��̾� �������� Ű


    public void collectAndSaveImg(Texture2D image, string eventType)
    {

        // �̹����� Base64�� ���ڵ��Ͽ� ���ڿ��� ��ȯ
        string base64EncodedImage = System.Convert.ToBase64String(image.EncodeToPNG());

        // �̺�Ʈ Ÿ�Կ� ���� �÷��̾� ���������� ����
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

        // ����� ������ ����
        PlayerPrefs.Save();
    }
}
