using UnityEngine;
using UnityEngine.UI;

public class CollectAndSaveImg : MonoBehaviour
{
    public GameObject saveImgCav;
    private const string EAIMG_KEY = "EAIMG"; // EAIMG 이미지를 저장할 플레이어 프레프스 키
    private const string SAIMG_KEY = "SAIMG"; // SAIMG 이미지를 저장할 플레이어 프레프스 키

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
            

            RawImage imageToCollect = GameObject.Find("saveImgCav").GetComponentInChildren<RawImage>(); // 수집할 이미지를 보유하는 UI 요소에 대한 참조
            collectAndSaveImg(imageToCollect, 0, EAIMG_KEY);

        }
        else
        {
            saveImgCav.gameObject.SetActive(false);
        }

        
    }

    public void collectAndSaveImg(RawImage rawImage, int index, string eventType)
    {
        // RawImage의 텍스처를 가져옴
        Texture2D sourceTexture = TextureFromRawImage(rawImage);

        if (sourceTexture != null)
        {
            // 이미지를 Base64로 인코딩하여 문자열로 변환
            byte[] bytes = sourceTexture.EncodeToPNG();
            string base64EncodedImage = System.Convert.ToBase64String(bytes);

            // 이벤트 타입과 인덱스에 따라 플레이어 프레프스에 저장
            string key = eventType + "_" + index;
            PlayerPrefs.SetString(key, base64EncodedImage);

            // 변경된 내용을 저장
            PlayerPrefs.Save();

            // 저장된 내용을 로그에 출력
            Debug.Log("이벤트가 실행되었습니다. 소스 이미지를 성공적으로 저장했습니다. (인덱스: " + index + ")");
        }
    }

    // RawImage의 텍스처를 가져와서 Texture2D로 변환하는 함수
    private Texture2D TextureFromRawImage(RawImage rawImage)
    {
        if (rawImage != null && rawImage.texture != null)
        {
            // RawImage의 Texture를 가져옴
            Texture2D texture = rawImage.texture as Texture2D;
            return texture;
        }
        else
        {
            Debug.LogError("RawImage 컴포넌트 또는 그 텍스처가 없습니다.");
            return null;
        }
    }
}
