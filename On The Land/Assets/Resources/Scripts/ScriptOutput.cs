using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Diagnostics;


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

    public Button skipBtn;

    // 배열 변수 선언
    public string[] texts;
    public int[] facialExpressions;
    public string[] names;
    public int count = 0;
    public Text nameText;
    public Text scripts;
    public float speed;

    private bool isButtonClicked = false;
    private Coroutine autoCoroutine;

    public GameObject nameScreen;

    private void Start()
    {
        setA.gameObject.SetActive(false);
        setB.gameObject.SetActive(false);

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

        nameScreen.gameObject.SetActive(false);
    }

    //클릭 시 다음 대사로
    private void Update()
    {
        if (!scrollRect.gameObject.activeSelf && !logbackBtn.gameObject.activeSelf && logBtn.gameObject.activeSelf && !isButtonClicked && !loadScreen.gameObject.activeSelf&&!nameScreen.gameObject.activeSelf)
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

            
            if (count == 333)
            {   
                CollectAndSaveImg cs = GetComponent<CollectAndSaveImg>();
                cs.HandleMouseClick();
            }
            if (count == 1 && SceneManager.GetActiveScene().name == "4. DAY1-2a")
            {
                nameScreen.gameObject.SetActive(true);
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

            autoCoroutine = StartCoroutine(AutoModeRoutine());
        }
        else
        {
            skipBtn.gameObject.SetActive(true);
            logBtn.gameObject.SetActive(true);
            loadBtn.gameObject.SetActive(true);
            autoBtnText.text = "AUTO"; // 버튼 텍스트를 "자동진행"으로 변경합니다.
            if (autoCoroutine != null)
                StopCoroutine(autoCoroutine);
        }
    }
    private IEnumerator AutoModeRoutine()
    {
        while (count < texts.Length)
        {
            HandleMouseClick();
            yield return new WaitForSeconds(0.5f * (speed + 1));
        }
    }
}
