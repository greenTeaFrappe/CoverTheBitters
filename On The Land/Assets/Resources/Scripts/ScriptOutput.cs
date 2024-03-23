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

    public Button loadBtn;
    public Button loadBackBtn;

    public GameObject loadScreen;
    public GameObject saveImgCav;


    public Button skipBtn;

    // 배열 변수 선언
    public string[] texts;
    public int[] facialExpressions;
    public string[] names;

    public Text nameText;
    public Text scripts;

    private bool isButtonClicked = false;

    public int count=0;


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
        if(count< texts.Length)
        {
            nameText.text = names[count];
            scripts.text = texts[count];

            //state 패턴 적용
            ScriptOutputState state = GetComponent<ScriptOutputState>();
            state.SOState(facialExpressions[count], names[count]);

            if(count==3)
            {
                Debug.Log("이벤트가 발생했습니다.");
                saveImgCav.gameObject.SetActive(true);
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

}
