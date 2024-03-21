using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScriptOutput : MonoBehaviour
{
    public Button setA;
    public Button setB;

    public Button logBtn;
    public Button backBtn;
    public ScrollRect scrollRect;

    public Button autoBtn;
    public Text autoBtnText; // 자동진행 버튼의 텍스트를 변경하기 위한 변수 추가

    public GameObject loadScreen;

    public Button skipBtn;

    // 배열 변수 선언
    public string[] texts;
    public int[] facialExpressions;
    public string[] names;

    public Text nameText;
    public Text scripts;

    public bool isButtonClicked = false;

    public int count=0;

    private float timer = 0f;
    private float interval = 1f; // 1초 간격

    //자동진행
    private void autoBtnClick()
    {
        isButtonClicked = !isButtonClicked; // 자동 진행 상태를 토글합니다.
        //error : save와 log 버튼 클릭해도 자동진행이 됨
        if (isButtonClicked)
        {
            autoBtnText.text = "일시정지"; // 버튼 텍스트를 "일시정지"로 변경합니다.
            InvokeRepeating(nameof(HandleMouseClick), 0f, 1f);
        }
        else
        {
            autoBtnText.text = "자동진행"; // 버튼 텍스트를 "자동진행"으로 변경합니다.
            CancelInvoke(nameof(HandleMouseClick));
        }

    }


    private void Start()
    {
       
        setA.gameObject.SetActive(false);
        setB.gameObject.SetActive(false);

        nameText.text = names[count];
        scripts.text = texts[count];

        //state 패턴 적용해야함
        ScriptOutputState state = GetComponent<ScriptOutputState>();
        state.SOState(facialExpressions[count], names[count]);
        count++;

        autoBtn.onClick.AddListener(autoBtnClick);
        skipBtn.onClick.AddListener(() =>
        {
            count = texts.Length;
            HandleMouseClick();
        });

    }

    //클릭 시 다음 대사로
    private void Update()
    {
        if (!scrollRect.gameObject.activeSelf && !backBtn.gameObject.activeSelf && logBtn.gameObject.activeSelf && !isButtonClicked && !loadScreen.gameObject.activeSelf)
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

            //state 패턴 적용해야함
            ScriptOutputState state = GetComponent<ScriptOutputState>();
            state.SOState(facialExpressions[count], names[count]);
            count++;
        }
        else
        {
            setA.gameObject.SetActive(true);
            setB.gameObject.SetActive(true);
        }
    }

}
