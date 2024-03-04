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
            // 모두 삭제할 생각이면 해당 코드 주석 풀기
            // PlayerPrefs.DeleteAll();

            int slotIndex = i; // Corrected closure issue
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
        //좌클릭 & 데이터가 있는 경우에만 load -> 인데 왜 더블클릭만 인식될까요ㅠㅠㅠㅠㅠㅠㅠㅠㅠㅠㅠ
        if (Input.GetMouseButtonDown(0) && slots[slotIndex].GetComponentInChildren<Text>().text != "비어있음")
        {
            Debug.Log("hi");
            SceneManager.LoadScene(slots[slotIndex].GetComponentInChildren<Text>().text); // Corrected scene loading
        }
        else
        {
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

}
