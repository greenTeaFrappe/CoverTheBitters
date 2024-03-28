using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using System;

public class select : MonoBehaviour
{
    public Button[] slots;     // Corrected variable name

    bool[] saveFile = new bool[5]; // 세이브 파일이 있는지 여부를 저장하는 배열

    public GameObject popUpScreen;
    public Button saveButton;
    public Button loadButton;
    public Button deleteButton;
    
    void Start()
    {
        popUpScreen.SetActive(false);
        InitializeSlots();
    }


    // 각 슬롯 초기화
    void InitializeSlots()  
    {
        
        for (int i = 0; i < 5; i++)
        {
            UnityEngine.Debug.Log(saveFile[i]);
            int slotIndex = i; // 각 반복에서 새로운 변수를 생성하여 클로저 변수로 사용
            slots[slotIndex].onClick.AddListener(() =>
            {
                UnityEngine.Debug.Log("slot add listener"); // Specify UnityEngine namespace
                OnSlotClicked(slotIndex);
            });

            // 저장된 데이터가 있는 경우 표시
            if (PlayerPrefs.HasKey($"Slot{i}"))
            {
                saveFile[i] = true;
                string savedData = PlayerPrefs.GetString($"Slot{i}");
                string[] dataParts = savedData.Split('|');
                slots[i].GetComponentInChildren<Text>().text = dataParts[0];
            }
            else
            {
                slots[i].GetComponentInChildren<Text>().text = "비어있음" ;
            }
        }
    }

    // 슬롯 클릭 이벤트 처리
    public void OnSlotClicked(int slotIndex)
    {
        // 슬롯이 비어있지 않은 경우
        if (slots[slotIndex].GetComponentInChildren<Text>().text != "비어있음")
        {
            popUpScreen.SetActive(true); // 팝업 화면을 활성화합니다.

            // 저장 버튼 클릭 시 동작
            saveButton.onClick.RemoveAllListeners(); // 기존 리스너 제거
            saveButton.onClick.AddListener(() =>
            {
                Save(slotIndex);
                popUpScreen.SetActive(false);
            });

            // 로드 버튼 클릭 시 동작
            loadButton.onClick.RemoveAllListeners(); // 기존 리스너 제거
            loadButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(slots[slotIndex].GetComponentInChildren<Text>().text);
            });

            // 삭제 버튼 클릭 시 동작
            deleteButton.onClick.RemoveAllListeners(); // 기존 리스너 제거
            deleteButton.onClick.AddListener(() =>
            {
                PlayerPrefs.DeleteKey($"Slot{slotIndex}");
                PlayerPrefs.Save();
                slots[slotIndex].GetComponentInChildren<Text>().text = "비어있음";
                popUpScreen.SetActive(false);
            });
        }
        else
        {
            Save(slotIndex);
        }
    }

    // 현재 씬 정보를 해당 슬롯에 저장
    private void Save(int slotIndex)
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        string currentTime = DateTime.Now.ToString();
        if (currentSceneName != "4. MAIN")
        {
            PlayerPrefs.SetString($"Slot{slotIndex}", $"{currentSceneName}|{currentTime}");
            PlayerPrefs.Save();
            slots[slotIndex].GetComponentInChildren<Text>().text = currentSceneName;
        }
    }
}
