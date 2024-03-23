using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ScriptOutput : MonoBehaviour
{
    public Button setA;
    public Button setB;

    public Button logBtn;
    public Button logbackBtn;
    public ScrollRect scrollRect;

    public Button autoBtn;
    public Text autoBtnText; // 자동진행 버튼의 텍스트를 변경하기 위한 변수 추가

    public GameObject loadScreen;
    public Button loadBtn;
    public Button loadBackBtn;


    public GameObject saveImgCav;
    private const string EAIMG_KEY = "EAIMG"; // EAIMG 이미지를 저장할 플레이어 프레프스 키
    private const string SAIMG_KEY = "SAIMG"; // SAIMG 이미지를 저장할 플레이어 프레프스 키
    

    public Button skipBtn;

    // 배열 변수 선언
    public string[] texts;
    public int[] facialExpressions;
    public string[] names;
    public int count = 0;
    public Text nameText;
    public Text scripts;

    private bool isButtonClicked = false;

    private void Start()
    {
        setA.gameObject.SetActive(false);
        setB.gameObject.SetActive(false);
        saveImgCav.gameObject.SetActive(false);

        HandleMouseClick();

        autoBtn.onClick.AddListener(autoBtnClick);
        skipBtn.onClick.AddListener(() =>
        {
            count = texts.Length;
            HandleMouseClick();
        });

        loadScreen.gameObject.SetActive(false);

        loadBtn.onClick.AddListener(() =>
        {
            loadScreen.gameObject.SetActive(true);
            loadBackBtn.onClick.AddListener(() =>
            {
                loadScreen.gameObject.SetActive(false);
            });
        });

    }

    //클릭 시 다음 대사로
    private void Update()
    {
        if (!scrollRect.gameObject.activeSelf && !logbackBtn.gameObject.activeSelf && logBtn.gameObject.activeSelf && !isButtonClicked && !loadScreen.gameObject.activeSelf)
        {

            // 마우스 클릭 감지
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
            {

                HandleMouseClick();
                //클릭 처리
            }
        }
    }

    private void HandleMouseClick()
    {
        if (count < texts.Length)
        {
            nameText.text = names[count];
            scripts.text = texts[count];

            //state 패턴 적용
            ScriptOutputState state = GetComponent<ScriptOutputState>();
            state.SOState(facialExpressions[count], names[count]);

            if (count == 3)
            {
                saveImgCav.gameObject.SetActive(true);

                RawImage imageToCollect = GameObject.Find("saveImgCav").GetComponentInChildren<RawImage>(); // 수집할 이미지를 보유하는 UI 요소에 대한 참조
                collectAndSaveImg(imageToCollect,0, EAIMG_KEY);

            }
            else
            {
                saveImgCav.gameObject.SetActive(false);
            }

            count++;
        }
        else
        {
            setA.gameObject.SetActive(true);
            setB.gameObject.SetActive(true);
        }
    }

    //자동진행
    private void autoBtnClick()
    {
        isButtonClicked = !isButtonClicked; // 자동 진행 상태를 토글합니다.

        if (isButtonClicked)
        {

            autoBtnText.text = "STOP"; // 버튼 텍스트를 "일시정지"로 변경합니다.

            skipBtn.gameObject.SetActive(false);
            logBtn.gameObject.SetActive(false);
            loadBtn.gameObject.SetActive(false);

            // 마우스 클릭 감지
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
            {

                autoBtnClick();
                --count;
            }

            InvokeRepeating(nameof(HandleMouseClick), 0f, 1f);
        }
        else
        {
            skipBtn.gameObject.SetActive(true);
            logBtn.gameObject.SetActive(true);
            loadBtn.gameObject.SetActive(true);
            autoBtnText.text = "AUTO"; // 버튼 텍스트를 "자동진행"으로 변경합니다.
            CancelInvoke(nameof(HandleMouseClick));
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
