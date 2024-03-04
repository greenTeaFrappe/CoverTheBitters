using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class select : MonoBehaviour
{
    public Button[] slots;     // Corrected variable name

    bool[] saveFile = new bool[4]; // 세이브 파일이 있는지 여부를 저장하는 배열

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            int slotIndex = i; // Corrected closure issue

            // 각 버튼에 클릭 이벤트를 추가합니다.
            Debug.Log(slots[i]);
            slots[i].onClick.AddListener(() => OnSlotClicked(slotIndex));


            if (PlayerPrefs.HasKey($"Slot{i}"))  // 데이터가 있는 경우
            {
                saveFile[i] = true; // 해당 슬롯을 true로 설정

                // 슬롯의 데이터를 로드합니다.
                string savedData = PlayerPrefs.GetString($"Slot{i}");
                string[] dataParts = savedData.Split('|');

                // 버튼에 씬 번호를 표시합니다.
                slots[i].GetComponentInChildren<Text>().text = dataParts[0];
                
                
            }
            else  // 데이터가 없는 경우
            {
                slots[i].GetComponentInChildren<Text>().text = "비어있음";
            }
        }

    }


    private void OnSlotClicked(int slotIndex) // Corrected method signature
    {
        //좌클릭 & 데이터가 있는 경우에만 load 
        if (Input.GetMouseButtonDown(0) && IsSlotOccupied(slotIndex))
        {
            SceneManager.LoadScene(slots[slotIndex].GetComponentInChildren<Text>().text); // Corrected scene loading
        }
        else
        {
            Debug.Log("hi");
            // 현재 씬의 이름을 가져옵니다.
            string currentSceneName = SceneManager.GetActiveScene().name;

            // 현재 시간을 가져와 문자열로 변환합니다.
            string currentTime = DateTime.Now.ToString();

            // PlayerPrefs에 "Slot{i}" 키를 사용하여 현재 씬 이름과 현재 시간을 저장합니다.
            PlayerPrefs.SetString($"Slot{slotIndex}", $"{currentSceneName}|{currentTime}");

            // 변경 사항을 저장합니다.
            PlayerPrefs.Save();

            slots[slotIndex].GetComponentInChildren<Text>().text = currentSceneName;
        }

    }

    public bool IsSlotOccupied(int slotNumber)
    {
        return saveFile[slotNumber]; // 해당 슬롯 번호의 데이터 유무를 반환합니다.
    }

}
