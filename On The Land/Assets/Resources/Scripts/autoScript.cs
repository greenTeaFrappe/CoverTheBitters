//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using static System.Net.Mime.MediaTypeNames;
//
//public class autoScript : MonoBehaviour
//{
//    public Button autoBtn;
//    public Text[] autoBtnText; // �ڵ����� ��ư�� �ؽ�Ʈ�� �����ϱ� ���� ���� �߰�
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
//        isButtonClicked = !isButtonClicked; // �ڵ� ���� ���¸� ����մϴ�.
//        float speed = 1f;
//
//        if (isButtonClicked)
//        {
//            autoBtnText.text = "STOP"; // ��ư �ؽ�Ʈ�� "�Ͻ�����"�� �����մϴ�.
//
//            skipBtn.gameObject.SetActive(false);
//            logBtn.gameObject.SetActive(false);
//            loadBtn.gameObject.SetActive(false);
//
//            // ���콺 Ŭ�� ����
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
//            autoBtnText.text = "AUTO"; // ��ư �ؽ�Ʈ�� "�ڵ�����"���� �����մϴ�.
//            CancelInvoke(nameof(HandleMouseClick));
//        }
//    }
//}
