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
                Debug.Log("이벤트가 발생했습니다.");

                saveImgCav.gameObject.SetActive(true);

                Image imageToCollect = GameObject.Find("saveImgCav").GetComponentInChildren<Image>(); // 수집할 이미지를 보유하는 UI 요소에 대한 참조
                collectAndSaveImg(imageToCollect, EAIMG_KEY);

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




    public void collectAndSaveImg(Image image, string eventType)
    {
        // collectButton의 이미지를 Texture2D로 변환
        Texture2D imageTexture = TextureFromImage(image);
        Debug.Log("이벤트가 실행되었습니다.");
        if (imageTexture != null)
        {
            // 이미지를 Base64로 인코딩하여 문자열로 변환
            byte[] bytes = imageTexture.EncodeToPNG();
            string base64EncodedImage = System.Convert.ToBase64String(bytes);

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
            Debug.Log("저장되었습니다.");
        }

        Debug.Log("저장되지 않았습니다.");
    }

    // Image의 텍스처를 가져와서 Texture2D로 변환하는 함수
    private Texture2D TextureFromImage(Image image)
    {
        Texture2D texture = null;
        if (image != null && image.mainTexture != null)
        {
            texture = new Texture2D(image.mainTexture.width, image.mainTexture.height);
            RenderTexture currentRT = RenderTexture.active;
            RenderTexture.active = (RenderTexture)image.mainTexture; //여기서 에러가 나ㅠㅠ 아오 시발~~!!
            texture.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);
            texture.Apply();
            RenderTexture.active = currentRT;
        }
        return texture;

    }
}
