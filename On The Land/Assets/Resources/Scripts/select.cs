using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class select : MonoBehaviour
{
    public Button[] slots;

    bool[] saveFile = new bool[5]; // 세이브 파일이 있는지 여부를 저장하는 배열

    public GameObject popUpScreen;
    public GameObject settingPopUpScreen;
    public Button saveButton;
    public Button loadButton;
    public Button deleteButton;
    public Button settingBtn;
    public Button settingBackBtn;

    void Start()
    {
        popUpScreen.SetActive(false);
        settingPopUpScreen.SetActive(false);
        settingBtn.gameObject.SetActive(true);
        settingBackBtn.gameObject.SetActive(false);
        settingBtn.onClick.AddListener(TaskOnClick);
        InitializeSlots();
    }

    // 각 슬롯 초기화
    void InitializeSlots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            int slotIndex = i; // 각 반복에서 새로운 변수를 생성하여 클로저 변수로 사용
            slots[slotIndex].onClick.AddListener(() =>
            {
                UnityEngine.Debug.Log("slot add listener");
                OnSlotClicked(slotIndex);
            });

            // 저장된 데이터가 있는 경우 표시
            if (PlayerPrefs.HasKey($"Slot{slotIndex}"))
            {
                saveFile[slotIndex] = true;
                string savedData = PlayerPrefs.GetString($"Slot{slotIndex}");
                string[] dataParts = savedData.Split('|');
                // 새로운 데이터 형식에 따라 슬롯 텍스트 업데이트
                slots[slotIndex].GetComponentInChildren<Text>().text = $"파일 {slotIndex + 1}\t\t{dataParts[0]}\n\t\t\t\t{dataParts[1]}\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t{dataParts[2]}";
            }
            else
            {
                slots[slotIndex].GetComponentInChildren<Text>().text = "비어있음";
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
                string savedData = PlayerPrefs.GetString($"Slot{slotIndex}");
                string[] dataParts = savedData.Split('|');
                SceneManager.LoadScene(dataParts[0]);
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
        string location = "칵테일 바"; // 장소를 지정합니다. 필요에 따라 동적으로 변경할 수 있습니다.
        string currentTime = DateTime.Now.ToString("HH:mm:ss"); // 시간을 저장합니다.

        if (currentSceneName != "4. MAIN")
        {
            PlayerPrefs.SetString($"Slot{slotIndex}", $"{currentSceneName}|{location}|{currentTime}");
            PlayerPrefs.Save();
            slots[slotIndex].GetComponentInChildren<Text>().text = $"파일 {slotIndex + 1}\t\t{currentSceneName}\n\t\t\t\t{location}\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t{currentTime}";
        }
    }

    void TaskOnClick()
    {
        settingBtn.gameObject.SetActive(false);
        settingPopUpScreen.gameObject.SetActive(true);
        settingBackBtn.gameObject.SetActive(true);

        settingBackBtn.onClick.AddListener(Task2OnClick);
    }

    void Task2OnClick()
    {
        settingBtn.gameObject.SetActive(true);
        settingBackBtn.gameObject.SetActive(false);
        settingPopUpScreen.gameObject.SetActive(false);
    }
}
