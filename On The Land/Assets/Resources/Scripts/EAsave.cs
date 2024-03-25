using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EAsave : MonoBehaviour
{
    public RawImage image = null;
    public int i = 0;
    private const string EAIMG_KEY = "EAIMG"; // EAIMG �̹����� ������ �÷��̾� �������� Ű
    public string sceneName; // �̵��� ���� �̸�
    
    void Start()
    {
        collectAndSaveImg(image, i, EAIMG_KEY);

    }
    private void Update()
    {
        // ���콺 ���� ��ư�� Ŭ���Ǹ�
        if (Input.GetMouseButtonDown(0))
        {
            // �ٸ� ������ ��ȯ
            ChangeScene();
        }
    }
    void ChangeScene()
    {
        // sceneName ������ ������ ������ ��ȯ
        SceneManager.LoadScene(sceneName);
    }

    public void collectAndSaveImg(RawImage rawImage, int index, string eventType)
    {
        // RawImage�� �ؽ�ó�� ������
        Texture2D sourceTexture = TextureFromRawImage(rawImage);

        if (sourceTexture != null)
        {
            // �̹����� Base64�� ���ڵ��Ͽ� ���ڿ��� ��ȯ
            byte[] bytes = sourceTexture.EncodeToPNG();
            string base64EncodedImage = System.Convert.ToBase64String(bytes);

            // �̺�Ʈ Ÿ�԰� �ε����� ���� �÷��̾� ���������� ����
            string key = eventType + "_" + index;
            PlayerPrefs.SetString(key, base64EncodedImage);

            // ����� ������ ����
            PlayerPrefs.Save();

            // ����� ������ �α׿� ���
            Debug.Log("�̺�Ʈ�� ����Ǿ����ϴ�. �ҽ� �̹����� ���������� �����߽��ϴ�. (�ε���: " + index + ")");
        }
    }

    // RawImage�� �ؽ�ó�� �����ͼ� Texture2D�� ��ȯ�ϴ� �Լ�
    private Texture2D TextureFromRawImage(RawImage rawImage)
    {
        if (rawImage != null && rawImage.texture != null)
        {
            // RawImage�� Texture�� ������
            Texture2D texture = rawImage.texture as Texture2D;
            return texture;
        }
        else
        {
            Debug.LogError("RawImage ������Ʈ �Ǵ� �� �ؽ�ó�� �����ϴ�.");
            return null;
        }
    }
}
