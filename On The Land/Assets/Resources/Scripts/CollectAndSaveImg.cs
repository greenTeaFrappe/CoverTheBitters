using UnityEngine;
using UnityEngine.UI;

public class CollectAndSaveImg : MonoBehaviour
{
    public GameObject saveImgCav;
    private const string EAIMG_KEY = "EAIMG"; // EAIMG �̹����� ������ �÷��̾� �������� Ű
    private const string SAIMG_KEY = "SAIMG"; // SAIMG �̹����� ������ �÷��̾� �������� Ű

    // Start is called before the first frame update
    void Start()
    {
        saveImgCav.gameObject.SetActive(false);
    }

    public void HandleMouseClick()
    {
        ScriptOutput so = GetComponent<ScriptOutput>();

        if (so.count == 3)
        {
            saveImgCav.gameObject.SetActive(true);
            

            RawImage imageToCollect = GameObject.Find("saveImgCav").GetComponentInChildren<RawImage>(); // ������ �̹����� �����ϴ� UI ��ҿ� ���� ����
            collectAndSaveImg(imageToCollect, 0, EAIMG_KEY);

        }
        else
        {
            saveImgCav.gameObject.SetActive(false);
        }

        
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
