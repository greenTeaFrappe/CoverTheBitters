//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using static System.Net.Mime.MediaTypeNames;
//
//public class autoScript : MonoBehaviour
//{
//    public Button autoBtn;
//    public Text[] autoBtnText; // 자동진행 버튼의 텍스트를 변경하기 위한 변수 추가
//
//
//    // Start is called before the first frame update
//    void Start()
//    {
//        
//    }
//
//    // Update is called once per frame
//    void Update()
//    {
//        
//    }
//
//    private void autoBtnClick()
//    {
//        isButtonClicked = !isButtonClicked; // 자동 진행 상태를 토글합니다.
//        float speed = 1f;
//
//        if (isButtonClicked)
//        {
//            autoBtnText.text = "STOP"; // 버튼 텍스트를 "일시정지"로 변경합니다.
//
//            skipBtn.gameObject.SetActive(false);
//            logBtn.gameObject.SetActive(false);
//            loadBtn.gameObject.SetActive(false);
//
//            // 마우스 클릭 감지
//            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
//            {
//
//                autoBtnClick();
//                --count;
//            }
//
//            InvokeRepeating(nameof(HandleMouseClick), 0f, 1f);
//        }
//        else
//        {
//            skipBtn.gameObject.SetActive(true);
//            logBtn.gameObject.SetActive(true);
//            loadBtn.gameObject.SetActive(true);
//            autoBtnText.text = "AUTO"; // 버튼 텍스트를 "자동진행"으로 변경합니다.
//            CancelInvoke(nameof(HandleMouseClick));
//        }
//    }
//}
