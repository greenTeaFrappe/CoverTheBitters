using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ScriptOutput : MonoBehaviour
{
    public Button[] btns;

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
    public Sprite[] pfpImages;
    public string[] locations;

    public Text locationText;

    public int count = 0;
    public Text nameText;
    public Text scripts;
    public float speed;

    private bool isButtonClicked = false;
    private Coroutine autoCoroutine;

    public GameObject nameScreen;

    private void Start()
    {
        for(int i=0; i<btns.Length; i++)
        {
            btns[i].gameObject.SetActive(false);
        }

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

        InsertPlayerName();
    }

    private void InsertPlayerName()
    {
        // PlayerPrefs에서 저장된 플레이어 이름을 불러옵니다.
        string playerName = PlayerPrefs.GetString("PlayerName", "Player");
        string firstName = PlayerPrefs.GetString("FirstName", "First");
        string secondName = PlayerPrefs.GetString("SecondName", "Second"); // 여기 수정

        // texts 배열에서 플레이어 이름이 들어갈 부분을 설정합니다.
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i] = texts[i].Replace("{PLAYER_NAME}", playerName);
            texts[i] = texts[i].Replace("{FIRST_NAME}", firstName);
            texts[i] = texts[i].Replace("{SECOND_NAME}", secondName);
        }
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
            locationText.text = locations[count];

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
            if(count == 3&&SceneManager.GetActiveScene().name == "4. DAY1-2a")
            {
                InsertPlayerName();
            }
            count++;
        }
        else
        {
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].gameObject.SetActive(true);
            }
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
